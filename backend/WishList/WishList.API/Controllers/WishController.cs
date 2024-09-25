using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using WishList.API.Contracts;
using WishList.API.Dto;
using WishList.API.Services;
using WishList.DataAccess.Postgres;
using WishList.DataAccess.Postgres.Interface;
using WishList.DataAccess.Postgres.Repositories;

namespace WishList.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WishController : ControllerBase
    {
        private readonly WishListDbContext _dbContext;
        public WishController(WishListDbContext dbContext)
        {
            _dbContext = dbContext;
            
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateWishRequest request, CancellationToken clt)
        {
            var wish = new WishEntity(request.Name, request.Price, request.Description, request.Link);

            await _dbContext.AddAsync(wish, clt);
            await _dbContext.SaveChangesAsync(clt);

            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> GetOptions([FromQuery] GetWishRequest request, CancellationToken clt)
        {
            var wishQuery = _dbContext.Wish
                .Where(n => string.IsNullOrEmpty(request.Search) ||
                n.Name.ToLower().Contains(request.Search.ToLower())); //15.51 закончит тайм код)))

            Expression<Func<WishEntity, object>> selectorKey = request.SortItem?.ToLower() switch
            {
                "date" => wish => wish.Created,
                "name" => wish => wish.Name,
                _ => wish => wish.Id,
            };

            if (request.SortOrder == "desc")
            {
                wishQuery = wishQuery.OrderByDescending(selectorKey);
            }
            else
            {
                wishQuery = wishQuery.OrderBy(n => n.Created);
            }
            var wishDtos = await wishQuery
                .Select(n => new WishDTO(n.Id, n.Name, n.Price, n.Description, n.Link, n.Created))
                .ToListAsync(clt);

            return Ok(new GetWishResponse(wishDtos));
        }
        /*[HttpGet]
        public async Task<ActionResult<List<GetWishRequest>>> GetWish(CancellationToken clt)
        {
            var wish = await _wishService.GetAllWish();

            var response = wish.Select(b => new WishDTO(b.Id, b.Name, b.Price, b.Description, b.Created));
                

            return Ok(response);
        }*/



    }
}

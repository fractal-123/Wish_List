using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using WishList.API.Contracts;
using WishList.API.Dto;
using WishList.API.Services;
using WishList.DataAccess.Postgres;

namespace WishList.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly WishListDbContext _dbContext;
        public UserController(WishListDbContext dbContext)
        {
            _dbContext = dbContext;

        }
        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] CreateUserRequest request, CancellationToken clt)
        {
            var user = new UserEntity(request.UserName, request.Gender, request.Password, request.Email, request.CountWishList);

            await _dbContext.AddAsync(user, clt);
            await _dbContext.SaveChangesAsync(clt);

            return Ok();
        }
        [HttpGet]
        public async Task<IActionResult> GetOptions([FromQuery] GetUserRequest request, CancellationToken clt)
        {
            var userQuery = _dbContext.Users
               .Where(n => string.IsNullOrEmpty(request.Search) ||
               n.UserName.ToLower().Contains(request.Search.ToLower()));

            Expression<Func<UserEntity, object>> selectorKey = request.SortItem?.ToLower() switch
            {   "countWishList" => user => user.CountWishList,
                "name" => user => user.UserName,
                _ => user => user.Id,
            };
            if (request.SortOrder == "desc")
            {
                userQuery = userQuery.OrderByDescending(selectorKey);
            }
            else
            {
                userQuery = userQuery.OrderBy(n => n.CountWishList);
            }
            var userDtos = await userQuery
                .Select(n => new UserDTO(n.UserName, n.Gender, n.PasswordHash, n.Email, n.CountWishList))
                .ToListAsync(clt);

            return Ok(new GetUserResponse(userDtos));
        }
    }
}

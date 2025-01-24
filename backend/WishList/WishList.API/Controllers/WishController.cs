using Microsoft.AspNetCore.Mvc;
using WishList.API.Dto;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using WishList.API.Contracts;
using WishList.DataAccess.Postgres;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Logging;
using WishList.API.Abstraction;
using WishList.API.Models;

namespace WishList.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WishController(IWishService wishes, ILogger<WishController> logger) : ControllerBase
    {

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateEditWishDTO createWishDTO, CancellationToken clt)
        {

            var userIdString = HttpContext.Session.GetString("UserId");
            if (string.IsNullOrEmpty(userIdString) || !Guid.TryParse(userIdString, out var userId))
            {
                return Unauthorized("User not logged in");
            }
            var result = await wishes.Create(createWishDTO, userId);

            return Ok(result);
        }

        [HttpGet("allWish")]
        public async Task<IActionResult> GetAllWish(CancellationToken clt)
        {

            logger.LogInformation("Method api/allWish GetAll started.");

            var result = await wishes.GetAllWish();

            logger.LogInformation($"Method api/allWish GetAll finished. Result count: {result.Count}");

            return Ok(new { wishes = result });
        }

        [HttpGet("auth-user-wishes")]
        public async Task<IActionResult> GetUserWishes(CancellationToken clt)
        {
            // Получаем UserId из сессии
            var userIdString = HttpContext.Session.GetString("UserId");
            if (string.IsNullOrEmpty(userIdString) || !Guid.TryParse(userIdString, out var userId))
            {
                return Unauthorized("User not logged in");
            }

            // Загружаем желания пользователя
            var result = await wishes.GetUserWishes(userId);

            return Ok(new { wishes = result });
        }

        [HttpPut("update-wish")]
        public async Task<IActionResult> UpdateWish(Guid wishId, [FromBody] CreateEditWishDTO editDTO, CancellationToken clt)
        {
            // Получаем ID пользователя из сессии
            var userIdString = HttpContext.Session.GetString("UserId");
            if (string.IsNullOrEmpty(userIdString) || !Guid.TryParse(userIdString, out var userId))
            {
                return Unauthorized("User not logged in");
            }
            var result = await wishes.Edit(editDTO, wishId);

            return Ok(new { wishes = result });



        }
        [HttpDelete("delete-wish")]
        public async Task<IActionResult> DeleteWish(Guid wishId, [FromBody] CreateEditWishDTO editDTO, CancellationToken clt)
        {
            // Получаем ID пользователя из сессии
            var userIdString = HttpContext.Session.GetString("UserId");
            if (string.IsNullOrEmpty(userIdString) || !Guid.TryParse(userIdString, out var userId))
            {
                return Unauthorized("User not logged in");
            }
            var result = await wishes.Edit(editDTO, wishId);

            return Ok(new { wishes = result });

        }
    
    } 
}

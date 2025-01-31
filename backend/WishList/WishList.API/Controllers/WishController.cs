using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WishList.API.Abstraction;
using WishList.API.Services;
using WishList.DataAccess.Postgres.Models;

namespace WishList.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WishController(IWishService wishes, ILogger<WishController> logger) : ControllerBase
    {

        [HttpPost]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> Create([FromForm] CreateEditWishDTO createWishDTO, IFormFile imageFile, CancellationToken clt)
        {
            logger.LogInformation($"хуууууууууууууууууууууууууууууууууууууууууууууууууууууууй{imageFile}");
            var userIdString = HttpContext.Session.GetString("UserId");
            if (string.IsNullOrEmpty(userIdString) || !Guid.TryParse(userIdString, out var userId))
            {
                return Unauthorized("User not logged in");
            }
            logger.LogInformation($"хуууууууууууууууууууууууууууууууууууууууууууууууууууууууй{ imageFile.FileName}");
            if (imageFile == null )
            {
                return Ok(new { Message = "Файл был загружен." });
            }
            try
            {
                var wishDto = await wishes.Create(createWishDTO, imageFile, userId);
                
                return Ok(wishDto);

            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    Message = ex.Message,
                    InnerException = ex.InnerException?.Message
                });
            }
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
        public async Task<IActionResult> DeleteWish(Guid wishId, [FromBody] CancellationToken clt)
        {
            // Получаем ID пользователя из сессии
            var userIdString = HttpContext.Session.GetString("UserId");
            if (string.IsNullOrEmpty(userIdString) || !Guid.TryParse(userIdString, out var userId))
            {
                return Unauthorized("User not logged in");
            }
            var result = await wishes.Delete(wishId);

            return Ok(new { wishes = result });

        }

        

    } 
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WishList.API.Abstraction;
using WishList.API.Contracts;
using WishList.DataAccess.Postgres;
using WishList.DataAccess.Postgres.Models;

namespace WishList.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController(IUserService user, ILogger<UserController> logger) : ControllerBase
    {


        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> RegisterUser([FromBody] RegistrationUserDTO registrationUser, CancellationToken clt)
        {
            //var existingUser = await _dbContext.Users
            //    .AsNoTracking()
            //    .FirstOrDefaultAsync(u => u.Email == registrationUser.Email, clt);

            //if (existingUser != null)
            //{
            //    return BadRequest(new { message = "Этот email уже используется." });
            //}

            //var hashedPassword = _passwordService.HashPassword(registrationUser.PasswordHash);
            //var user = new RegistrationUserDTO(registrationUser.UserName, hashedPassword, registrationUser.Email);

            var result = await user.Register(registrationUser);

            return Ok(result);
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> LoginUser([FromBody] LoginDto login, CancellationToken clt)
        {
            logger.LogInformation("авторизация успешна");
            var result = await user.Login(login, HttpContext);
            return Ok(result);
        }

        [HttpGet]
        [Route("get-all-users")]
        public async Task<IActionResult> GetOptions(CancellationToken clt)
        {

            var result = await user.GetAllUser();

            return Ok(result);
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WishList.API.Contracts;
using WishList.DataAccess.Postgres;
using WishList.API.Dto;

namespace WishList.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly WishListDbContext _dbContext;
        private readonly PasswordService _passwordService;


        public UserController(WishListDbContext dbContext)
        {
            _dbContext = dbContext;
            _passwordService = new PasswordService();

        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> RegisterUser([FromBody] RegistrationUserDTO registrationUser, CancellationToken clt)
        {
            var existingUser = await _dbContext.Users
                .AsNoTracking()
                .FirstOrDefaultAsync(u => u.Email == registrationUser.Email, clt);

            if (existingUser != null)
            {
                return BadRequest(new { message = "Этот email уже используется." });
            }

            var hashedPassword = _passwordService.HashPassword(registrationUser.PasswordHash);
            var user = new RegistrationUserDTO(registrationUser.UserName, hashedPassword, registrationUser.Email);

            try
            {
                await _dbContext.AddAsync(user, clt);
                await _dbContext.SaveChangesAsync(clt);


                return Ok(new { message = "Регистрация успешна." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Во время регистрации произошла ошибка.", details = ex.Message });
            }
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> LoginUser([FromBody] LoginDto login, CancellationToken clt)
        {

            if (string.IsNullOrWhiteSpace(login.Email) || string.IsNullOrWhiteSpace(login.PasswordHash))
            {
                return BadRequest(new { message = "Email и пароль обязательны." });
            }

            var user = await _dbContext.Users
                .FirstOrDefaultAsync(u => u.Email == login.Email);

            if (user == null)
            {
                return BadRequest(new { message = "Пользователь не найден." });
            }

            bool isPasswordValid = _passwordService.VerifyPassword(user.PasswordHash, login.PasswordHash);

            if (!isPasswordValid)
            {
                return BadRequest(new { message = "Неверный пароль." });
            }
            HttpContext.Session.SetString("UserId", user.Id.ToString());

            return Ok(new { message = "Авторизация успешна." });
        }



        [HttpGet]
        [Route("get-all-users")]
        public async Task<IActionResult> GetOptions(CancellationToken clt)
        {

            var userDtos = await _dbContext.Users
                .AsNoTracking()
                .Select(u => new UserDTO
                (
                    u.Id,
                    u.UserName,
                    u.Email,
                    u.PasswordHash,
                    u.Gender,
                    u.RegistrationDate,
                    u.CountWishList
                ))
                .ToListAsync(clt);

            return Ok(new GetUserResponse(userDtos));
        }
    }
}

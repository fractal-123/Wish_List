using WishList.DataAccess.Postgres;
using WishList.API.Abstraction;
using Microsoft.EntityFrameworkCore;
using WishList.DataAccess.Postgres.Models;
using Mapster;


namespace WishList.API.Services
{
    public class UserService(WishListDbContext context, PasswordService passwordService) : IUserService
    {
        public async Task<List<UserDTO>> GetAllUser()
        {
            var userEntity = await context.Users
                .AsNoTracking()
                .ToListAsync();

            return userEntity.Select(x => x.Adapt<UserDTO>()).ToList(); 
        }

        public async Task<string> Register(RegistrationUserDTO userRegisterModel)
        {
            var existingUser = await context.Users
                .AsNoTracking()
                .FirstOrDefaultAsync(u => u.Email == userRegisterModel.Email);

            if (existingUser != null)
            {
                throw new Exception("Этот email уже используется.");
            }
            

            var passwordHash = passwordService.HashPassword(userRegisterModel.PasswordHash);
            var user = new UserEntity(userRegisterModel.UserName,userRegisterModel.Email, passwordHash );

            try
            {
                await context.AddAsync(user);
                await context.SaveChangesAsync();

                var message = "Регистрация успешна.";
                return message;
            }
            catch (Exception ex)
            {

                var message = "Во время регистрации произошла ошибка. " + ex.Message.ToString();
                return message;
            }
        }

        public async Task<string> Login(LoginDto userLoginDto, HttpContext httpContext)
        {
            if (string.IsNullOrWhiteSpace(userLoginDto.Email) || string.IsNullOrWhiteSpace(userLoginDto.PasswordHash))
            {
                throw new Exception("Email и пароль обязательны.");

            }

            var user = await context.Users
                .FirstOrDefaultAsync(u => u.Email == userLoginDto.Email);

            if (user == null)
            {
                throw new Exception("Пользователь не найден.");
            }

            bool isPasswordValid = passwordService.VerifyPassword(user.PasswordHash, userLoginDto.PasswordHash);

            if (!isPasswordValid)
            {
                throw new Exception("Неверный пароль." );
            }

            httpContext.Session.SetString("UserId", user.Id.ToString());

            var message = "Авторизация успешна.";
            return message;
        }
    }
}

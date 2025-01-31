using WishList.DataAccess.Postgres.Models;

namespace WishList.API.Abstraction;

public interface IUserService
{
    Task<List<UserDTO>> GetAllUser();
    Task<string> Register(RegistrationUserDTO userRegisterModel);
    Task<string> Login(LoginDto userLoginDto, HttpContext httpContext);  
}
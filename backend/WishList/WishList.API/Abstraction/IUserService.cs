using WishList.API.Dto;

namespace WishList.API.Abstraction;

interface IUserService
{
    Task<List<UserDTO>> GetAllUser();
    //Task<UserResponse> Register(UserRegisterDto userRegisterModel);
    //Task<UserResponse> Login(UserLoginDto userLoginDto);  
}
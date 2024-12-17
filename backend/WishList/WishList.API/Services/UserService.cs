using WishList.DataAccess.Postgres;
using WishList.DataAccess.Postgres.Interface;

namespace WishList.API.Services
{
    public class UserService: IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<List<UserEntity>> GetAllUser()
        {
            return await _userRepository.GetUser();
        }
    }
}

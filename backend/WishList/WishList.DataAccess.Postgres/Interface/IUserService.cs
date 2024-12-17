using WishList.DataAccess.Postgres;

namespace WishList.API.Services
{
    public interface IUserService
    {
        Task<List<UserEntity>> GetAllUser();
    }
}

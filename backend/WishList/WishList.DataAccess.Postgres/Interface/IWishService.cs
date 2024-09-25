using WishList.DataAccess.Postgres;

namespace WishList.API.Services
{
    public interface IWishService
    {
        Task<List<WishEntity>> GetAllWish();
    }
}
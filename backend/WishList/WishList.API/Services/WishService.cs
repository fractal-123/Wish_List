using WishList.DataAccess.Postgres;
using WishList.DataAccess.Postgres.Interface;

namespace WishList.API.Services
{
    public class WishService : IWishService
    {
        private readonly IWishRepository _wishRepository;

        public WishService(IWishRepository wishRepository)
        {
            _wishRepository = wishRepository;
        }

        public async Task<List<WishEntity>> GetAllWish()
        {
            return await _wishRepository.Get();
        }
    }
}

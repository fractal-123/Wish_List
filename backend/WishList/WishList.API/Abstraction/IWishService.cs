using WishList.DataAccess.Postgres.Models;

namespace WishList.API.Abstraction
{
    public interface IWishService
    {
        Task<WishDTO> Create(CreateEditWishDTO createDTO, IFormFile imageFile, Guid userId);
        Task<List<WishDTO>> GetAllWish();
        Task<List<WishDTO>> GetUserWishes(Guid Id);
        Task<WishDTO> Edit(CreateEditWishDTO editDTO, Guid wishId);
        Task<string> Delete(Guid wishId);
    }
}

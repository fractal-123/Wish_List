using WishList.API.Dto;
using WishList.API.Models;
using WishList.API.Contracts;

namespace WishList.API.Abstraction
{
    public interface IWishService
    {
        Task<WishDTO> Create(CreateEditWishDTO createDTO, Guid userId);
        Task<List<WishDTO>> GetAllWish();
        Task<List<WishDTO>> GetUserWishes(Guid Id);
        Task<WishDTO> Edit(CreateEditWishDTO editDTO, Guid wishId);
        Task Delete(Guid wishId);
    }
}

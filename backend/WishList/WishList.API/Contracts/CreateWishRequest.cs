using WishList.DataAccess.Postgres;

namespace WishList.API.Contracts
{
    public record CreateWishRequest(string Name, decimal Price, string Description, string Link);
    
}

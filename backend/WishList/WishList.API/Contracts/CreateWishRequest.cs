namespace WishList.API.Contracts
{
    public record CreateWishRequest(/*Guid UserID ,*/string Name, decimal Price, string Description, string Link);
    
}

namespace WishList.API.Contracts
{
    public record GetWishRequest(string? Search, string? SortItem, string? SortOrder);
}

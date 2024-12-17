namespace WishList.API.Contracts
{
    public record GetUserRequest(string? Search, string? SortItem, string? SortOrder);
}


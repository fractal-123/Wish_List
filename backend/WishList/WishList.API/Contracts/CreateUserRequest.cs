namespace WishList.API.Contracts
{
    public record CreateUserRequest(string UserName, string Gender, string Password,  string Email, int CountWishList);
    
}

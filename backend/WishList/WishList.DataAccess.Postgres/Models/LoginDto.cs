namespace WishList.DataAccess.Postgres.Models;

public record LoginDto
{
    public string Email { get; set; }
    public string PasswordHash { get; set; }
}

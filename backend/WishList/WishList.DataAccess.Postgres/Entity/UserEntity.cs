namespace WishList.DataAccess.Postgres;

public class UserEntity
{
    public UserEntity(string userName,string passwordHash, string email)
    {
        UserName = userName;
        PasswordHash = passwordHash;
        Email = email;
    }
    public UserEntity(string userName, string gender, string passwordHash, string email, int countWishList) 
    {
        UserName = userName;
        Gender = gender;
        PasswordHash = passwordHash;
        Email = email;
        CountWishList = countWishList;
    }

    public Guid Id { get; set; }

    public string UserName { get;  set; }

    public string Gender { get; set; } = string.Empty;

    public string PasswordHash { get;   set; }

    public string Email { get;  set; }

    public int CountWishList { get; set; }
    public DateTime RegistrationDate { get; set; } = DateTime.UtcNow;

    public List<WishEntity> Wishes { get; set; }

    //public List<WishEntity> Wish { get; set; } = [];



}

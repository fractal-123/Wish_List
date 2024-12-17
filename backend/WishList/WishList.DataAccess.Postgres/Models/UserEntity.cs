namespace WishList.DataAccess.Postgres;

public class UserEntity
{
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

    //public List<WishEntity> Wish { get; set; } = [];


    public static UserEntity Create(string userName, string gender, string password, string email, int countWishList)
    {
        return new UserEntity(userName, gender, password, email, countWishList);
    }

}

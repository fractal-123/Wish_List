namespace WishList.DataAccess.Postgres;

public class WishEntity
{

    const int MAX_TITLE_LENGTH = 250;

    public WishEntity(string name, decimal price, string description, string link)
    {
       
        Name = name;
        Price = price;
        Description = description;
        Link = link;
        Created = DateTime.UtcNow;
    }

    public Guid Id { get; set; }

    //public Guid UserId { get; set; }

    //public UserEntity? User { get; set; }

    //public Guid WishListId {  get; set; }

    //public WishListEntity? WishList { get; set; }

    public string Name { get; set; } = string.Empty;

    //public byte[]? Image { get; set; }

    public string Link { get; init; } = string.Empty;

    public decimal Price { get; set; }

    public string Description { get; set; } = string.Empty;

    public DateTime Created { get; set;}


    public static (WishEntity Wish, string Error ) Create(Guid id, string name, decimal price, string description, string link, DateTime DateTime)
    {
        var error = string.Empty;

        if(string.IsNullOrEmpty(name) || name.Length > MAX_TITLE_LENGTH) 
        {
            error = " Title can not be empty or longer 250";
        }

        var wish = new WishEntity(name,price,description,link);

        return (wish,error);
    }
}


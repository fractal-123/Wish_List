namespace WishList.DataAccess.Postgres;

public class WishEntity
{

    public WishEntity(string name, decimal price, string description)
    {
        Name = name;
        Price = price;
        Description = description;
        Created = DateTime.UtcNow;
    }

    public Guid Id { get; set; }

    //public Guid UserId { get; set; }

    //public UserEntity? User { get; set; }

    //public Guid WishListId {  get; set; }

    //public WishListEntity? WishList { get; set; }

    public string Name { get; set; } = string.Empty;

    //public byte[]? Image { get; set; }

    //public string Link { get; init; } = string.Empty;

    public decimal Price { get; set; }

    public string Description { get; set; } = string.Empty;

    public DateTime Created { get; set;}
}


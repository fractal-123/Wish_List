namespace WishList.DataAccess.Postgres;

public class WishEntity
{
    public WishEntity(string name, decimal? price, string description, string? link)
    {

        Name = name;
        Price = price;
        Description = description;
        Link = link;
        Created = DateTime.UtcNow;
    }

    public Guid Id { get; set; }

    //public Guid WishListId {  get; set; }

    //public WishListEntity? WishList { get; set; }

    public string Name { get; set; } = string.Empty;

    //public byte[]? Image { get; set; }
    public string Link { get; set; } 
    public decimal? Price { get; set; }
    public string Description { get; set; } = string.Empty;
    public DateTime Created { get; set;}




    public Guid UserId { get; set; }

    // Навигационное свойство
    public UserEntity User { get; set; } = null!;


    
}


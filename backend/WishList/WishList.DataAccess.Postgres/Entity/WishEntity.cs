namespace WishList.DataAccess.Postgres;

public class WishEntity
{
    public WishEntity(string name, decimal price, string description, string link, string imagePath )
    {
        Name = name;
        Price = price;
        Description = description;
        Link = link;
        ImagePath = imagePath;
        Created = DateTime.UtcNow;

    }

    public Guid Id { get; set; }

    //public Guid WishListId {  get; set; }

    //public WishListEntity? WishList { get; set; }

    public string Name { get; set; } 
    public string ImagePath { get; set; }
    public string Link { get; set; } 
    public decimal Price { get; set; }
    public string Description { get; set; } 
    public DateTime Created { get; set;}

    public Guid UserId { get; set; }

    // Навигационное свойство
    public UserEntity User { get; set; } = null!;


    
}


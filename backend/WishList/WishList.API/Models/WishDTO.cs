namespace WishList.API.Dto;

//public record WishDTO(Guid Id, string Name, decimal Price, string Description, string? Link, DateTime Created);


public class WishDTO
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public decimal? Price { get; set; }
    public string? Description { get; set; }
    public string? Link { get; set; }
    public DateTime Created { get; set; }

}



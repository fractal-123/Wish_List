public class CreateWishRequest
{
    public string? Name { get; set; }
    public string? Description { get; set; }
    public string? Link { get; set; }
    public decimal Price { get; set; }
    public IFormFile? Photo { get; set; } // Название ДОЛЖНО совпадать с клиентом
}

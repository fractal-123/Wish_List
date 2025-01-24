namespace WishList.API.Models
{
    public class CreateEditWishDTO
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Link { get; set; }
        public decimal? Price{ get; set; }
    }
}

namespace WishList.DataAccess.Postgres.Interface
{
    public interface IWishRepository
    {
        Task<List<WishEntity>> Get();
    }
}
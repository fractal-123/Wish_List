namespace WishList.DataAccess.Postgres.Interface;


    public interface IUserRepository
    {
        Task<List<UserEntity>> GetUser();
    }


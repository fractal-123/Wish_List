using Microsoft.EntityFrameworkCore;
using WishList.DataAccess.Postgres.Interface;

namespace WishList.DataAccess.Postgres.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly WishListDbContext _dbContext;

        public UserRepository(WishListDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<UserEntity>> GetUser()
        {
            var userEntity = await _dbContext.Users
                .AsNoTracking()
                .ToListAsync();

            var user = userEntity
                .Select(b => UserEntity.Create(b.UserName, b.Gender, b.PasswordHash, b.Email, b.CountWishList))
                .ToList();
            return user;
        }
    }
}

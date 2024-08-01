using Microsoft.EntityFrameworkCore;

namespace WishList.DataAccess.Postgres.Repositories
{
    /*public class WishRepository

    {
        private readonly WishListDbContext _dbContext;

        public WishRepository(WishListDbContext dbContext) 
        {
            _dbContext = dbContext;
        }

        public async Task<List<WishEntity>> Get()
        {
            return await _dbContext.Wish
                .AsNoTracking()
                .OrderBy(c =>c.Price)
                .ToListAsync();
        }
    }*/
}

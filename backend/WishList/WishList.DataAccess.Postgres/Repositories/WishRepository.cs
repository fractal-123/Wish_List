using Microsoft.EntityFrameworkCore;
using WishList.DataAccess.Postgres.Interface;

namespace WishList.DataAccess.Postgres.Repositories
{
    public class WishRepository: IWishRepository

    {
        private readonly WishListDbContext _dbContext;

        public WishRepository(WishListDbContext dbContext) 
        {
            _dbContext = dbContext;
        }

        public async Task<List<WishEntity>> Get()
        {
            var wishEntity= await _dbContext.Wish
                .AsNoTracking()
                .ToListAsync();

            var wish = wishEntity
                .Select(b => WishEntity.Create(b.Id,/*b.UserId,*/ b.Name,b.Price,b.Description, b.Link,b.Created).Wish)
                .ToList();
            return wish;
        }
    }
}

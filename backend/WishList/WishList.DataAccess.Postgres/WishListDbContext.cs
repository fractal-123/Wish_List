using Microsoft.EntityFrameworkCore;



namespace WishList.DataAccess.Postgres
{
    public class WishListDbContext : DbContext
    {
        public WishListDbContext(DbContextOptions<WishListDbContext> options)
        : base(options) 
        {
        }
        public DbSet<UserEntity> Users { get; set; }
        public DbSet<WishEntity> Wishes { get; set; }

    }
}
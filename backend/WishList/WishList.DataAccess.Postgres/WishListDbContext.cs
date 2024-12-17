using Microsoft.EntityFrameworkCore;
using WishList.DataAccess.Postgres;
using WishList.DataAccess.Postgres.Configurations;


namespace WishList.DataAccess.Postgres
{
    public class WishListDbContext : DbContext
    {
        public WishListDbContext (DbContextOptions<WishListDbContext> options)
            : base(options)
        {
            
        }

        public DbSet<UserEntity> Users { get; set; }
        public DbSet<WishEntity> Wish { get; set; }

        //public DbSet<WishListEntity> WishList { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new WishConfiguration());
            //modelBuilder.ApplyConfiguration(new WishListConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}
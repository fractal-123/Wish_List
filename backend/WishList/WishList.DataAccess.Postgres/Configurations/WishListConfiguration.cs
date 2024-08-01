using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace WishList.DataAccess.Postgres.Configurations
{
    /*public class WishListConfiguration : IEntityTypeConfiguration<WishListEntity>
    {
        
            public void Configure(EntityTypeBuilder<WishListEntity> builder)
            {
                builder.HasKey(a => a.Id);

                builder.
                HasMany(a => a.Wish)
                .WithOne(c => c.WishList);

            }
        
    }*/
}

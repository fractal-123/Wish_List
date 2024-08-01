using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace WishList.DataAccess.Postgres.Configurations
{
   /* public class WishConfiguration : IEntityTypeConfiguration<WishEntity>
    {
        public void Configure(EntityTypeBuilder<WishEntity> builder)
        {
           builder.HasKey(a => a.Id);


            builder.
                 HasOne(a => a.WishList)
                 .WithMany(c => c.Wish);

            builder.
                HasOne(a => a.User)
                .WithMany(c => c.Wish);


        }
    }*/
}

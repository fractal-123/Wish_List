using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace WishList.DataAccess.Postgres;

public class UserConfiguration : IEntityTypeConfiguration<UserEntity>
{
    public void Configure(EntityTypeBuilder<UserEntity> builder)
    {
        /*builder.HasKey(a => a.Id);

        builder. 
            HasMany( a => a.Wish )
               .WithOne(c => c.User);*/
    }
}



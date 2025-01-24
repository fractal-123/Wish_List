using WishList.DataAccess.Postgres;
using WishList.API.Abstraction;
using Microsoft.EntityFrameworkCore;
using WishList.API.Dto;
using Mapster;


namespace WishList.API.Services
{
    public class UserService(WishListDbContext context) : IUserService
    {
        public async Task<List<UserDTO>> GetAllUser()
        {
            var userEntity = await context.Users
                .AsNoTracking()
                .ToListAsync();

            return userEntity.Select(x => x.Adapt<UserDTO>()).ToList(); 
        }

    }
}

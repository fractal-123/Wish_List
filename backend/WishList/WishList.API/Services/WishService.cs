using Microsoft.EntityFrameworkCore;
using WishList.API.Abstraction;
using WishList.API.Dto;
using WishList.DataAccess.Postgres;
using WishList.API.Models;
using Mapster;
using System.Linq.Expressions;
using WishList.API.Contracts;


namespace WishList.API.Services
{
    public class WishService(WishListDbContext context) : IWishService
    {
        public async Task<WishDTO> Create(CreateEditWishDTO createDTO,Guid userId)
        {
            
            var user = await context.Users.FirstOrDefaultAsync(u => u.Id == userId);
            if (user == null)
            {
                throw new Exception("User not found");
            }   

            user.Wishes = new List<WishEntity>();
            
            var wish = new WishEntity(createDTO.Name, createDTO.Price, createDTO.Description, createDTO.Link);

            user.Wishes.Add(wish);

            await context.SaveChangesAsync();

            var wishDto = new WishDTO
            {
                Id = wish.Id,
                Name = wish.Name,
                Price = wish.Price,
                Description = wish.Description,
                Link = wish.Link,
                Created = wish.Created
            };

            return wishDto;
        }

        public async Task<List<WishDTO>> GetAllWish()
        {
            

            var wishEntity = await context.Wishes
                .AsNoTracking()
                .ToListAsync();

            return wishEntity.Select(x => x.Adapt<WishDTO>()).ToList();

        }

        public async Task<List<WishDTO>> GetUserWishes(Guid userId)
        {
            var user = await context.Users
                .Include(u => u.Wishes) // Загружаем связанные желания
                .FirstOrDefaultAsync(u => u.Id == userId);

            if (user == null)
            {
                throw new Exception("User not found");
            }

            // Преобразуем желания в DTO
            var userWishesDto = user.Wishes
                .Select(wish => new WishDTO {
                    Id = wish.Id,
                    Name = wish.Name,
                    Price = wish.Price,
                    Description= wish.Description,
                    Link = wish.Link,
                    Created = wish.Created
                })
                .ToList();
            return userWishesDto;
        }

        public async Task<WishDTO> Edit(CreateEditWishDTO editDTO, Guid wishId)
        {
            var wish = await context.Wishes.FindAsync(wishId);

            if (wish == null)
            {
                throw new Exception("Wish not found");
            }

            wish.Name = editDTO.Name ?? wish.Name;
            wish.Price = editDTO.Price ?? wish.Price;
            wish.Description = editDTO.Description ?? wish.Description;
            wish.Link = editDTO.Link ?? wish.Link;

            // Сохраняем изменения
            await context.SaveChangesAsync();

            // Преобразуем обновленное желание в DTO
            return new WishDTO
            {
                Id = wish.Id,
                Name = wish.Name,
                Price = wish.Price,
                Description = wish.Description,
                Link = wish.Link,
                Created = wish.Created
            };
        }

        public Task Delete(Guid wishId)
        {
            throw new NotImplementedException();
        }
    }
}

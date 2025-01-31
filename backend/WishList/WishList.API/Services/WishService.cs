using Microsoft.EntityFrameworkCore;
using WishList.API.Abstraction;
using WishList.DataAccess.Postgres.Models;
using WishList.DataAccess.Postgres;
using Mapster;



namespace WishList.API.Services
{
    public class WishService(WishListDbContext context) : IWishService
    {
        public async Task<WishDTO> Create(CreateEditWishDTO createDTO, IFormFile imageFile, Guid userId)
        {
            Console.WriteLine("Processing image file...");
            var user = await context.Users.FirstOrDefaultAsync(u => u.Id == userId);
            if (user == null)
            {
                throw new Exception("User not found");
            }

            user.Wishes = new List<WishEntity>();

            // Сохраняем изображение на диск
            string imagePath = null!;
            if (imageFile != null && imageFile.Length > 0)
            {
                Console.WriteLine("Processing image file...");
                var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads");
                Directory.CreateDirectory(uploadsFolder);

                var fileName = Guid.NewGuid().ToString() + Path.GetExtension(imageFile.FileName);
                var filePath = Path.Combine(uploadsFolder, fileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await imageFile.CopyToAsync(stream);
                }

                imagePath = $"/uploads/{fileName}";
            }
            Console.WriteLine(imageFile);
            Console.WriteLine(imagePath);
            var wish = new WishEntity(createDTO.Name, createDTO.Price, createDTO.Description, createDTO.Link, imagePath);
            if (string.IsNullOrWhiteSpace(wish.Name))
            {
                throw new Exception("Wish name cannot be empty.");
            }
            user.Wishes.Add(wish);
            await context.SaveChangesAsync();

            return new WishDTO
            {
                Id = wish.Id,
                Name = wish.Name,
                Price = wish.Price,
                Description = wish.Description,
                Link = wish.Link,
                ImagePath = wish.ImagePath,
                Created = wish.Created
            };
        }
        //public async Task<WishDTO> Create(CreateEditWishDTO createDTO, Guid userId)
        //{

        //    var user = await context.Users.FirstOrDefaultAsync(u => u.Id == userId);
        //    if (user == null)
        //    {
        //        throw new Exception("User not found");
        //    }

        //    user.Wishes = new List<WishEntity>();

        //    var wish = new WishEntity(createDTO.Name, createDTO.Price, createDTO.Description, createDTO.Link);

        //    user.Wishes.Add(wish);

        //    await context.SaveChangesAsync();

        //    var wishDto = new WishDTO
        //    {
        //        Id = wish.Id,
        //        Name = wish.Name,
        //        Price = wish.Price,
        //        Description = wish.Description,
        //        Link = wish.Link,
        //        Created = wish.Created
        //    };

        //    return wishDto;
        //}



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
                .Include(u => u.Wishes)
                .FirstOrDefaultAsync(u => u.Id == userId);

            if (user == null)
            {
                throw new Exception("User not found");
            }

            var userWishesDto = user.Wishes
                .Select(wish => new WishDTO
                {
                    Id = wish.Id,
                    Name = wish.Name,
                    Price = wish.Price,
                    Description = wish.Description,
                    Link = wish.Link,
                    ImagePath = wish.ImagePath != null ?
                        $"http://localhost:5152{wish.ImagePath}" : null,
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
            wish.Price = editDTO.Price;
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

        public async Task<string> Delete(Guid wishId)
        {
            var wish = await context.Wishes.FindAsync(wishId);

            if (wish == null)
            {
                throw new Exception("Wish not found");
            }
            context.Wishes.Remove(wish); 
            await context.SaveChangesAsync();

            var message = "Желание удалено";
            return message;
        }
       

    }
}

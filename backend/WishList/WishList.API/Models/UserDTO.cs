namespace WishList.API.Dto;

public record UserDTO(Guid Id,string UserName, string Gender, string Password, string Email, DateTime RegistrationDate, int CountWishList );


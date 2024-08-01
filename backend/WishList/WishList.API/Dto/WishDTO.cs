namespace WishList.API.Dto;

public record WishDTO(Guid Id, string Name, decimal Price, string Description, DateTime Created);


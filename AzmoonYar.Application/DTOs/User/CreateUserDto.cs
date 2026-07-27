namespace AzmoonYar.Application.DTOs.User;

public record CreateUserDto(string FirstName, string LastName, string? UserName, string? Password,string PhoneNumber);
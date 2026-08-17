namespace AzmoonYar.Application.DTOs.User;

public record CreateUserDto(string FirstName, string LastName,string PhoneNumber,  string Password, string? Email);
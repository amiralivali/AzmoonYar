namespace AzmoonYar.Application.DTOs.User;

public record UpdateUserDto(string FirstName, string LastName,string PhoneNumber,  string Password, string? Email);
namespace AzmoonYar.Application.DTOs;

public record CreateUserDto(string FirstName, string LastName, string? UserName, string? Password,string PhoneNumber);
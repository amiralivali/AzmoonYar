namespace AzmoonYar.Application.DTOs;

public record UserDto(long Id,string FirstName,string LastName,string? UserName,string PhoneNumber,DateTimeOffset CreatedAt);
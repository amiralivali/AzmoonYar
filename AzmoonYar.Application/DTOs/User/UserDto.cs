namespace AzmoonYar.Application.DTOs.User;

public record UserDto(long Id,string FirstName,string LastName,string PhoneNumber,DateTimeOffset CreatedAt);
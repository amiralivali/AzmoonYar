namespace AzmoonYar.API.Contracts.User;

public record UserResponse(long Id,string FirstName,string LastName,string? UserName,string PhoneNumber,DateTimeOffset CreatedAt);
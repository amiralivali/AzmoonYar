namespace AzmoonYar.API.Contracts.User;

public record CreateUserRequest(string FirstName, string LastName, string? UserName, string? Password,string PhoneNumber);
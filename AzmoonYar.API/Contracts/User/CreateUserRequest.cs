namespace AzmoonYar.API.Contracts.User;

public record CreateUserRequest(string FirstName, string LastName,string PhoneNumber, string Password,string? Email);
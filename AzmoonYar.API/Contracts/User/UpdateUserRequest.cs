namespace AzmoonYar.API.Contracts.User;

public record UpdateUserRequest(string FirstName, string LastName,string PhoneNumber, string Password,string? Email);
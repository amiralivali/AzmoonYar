namespace AzmoonYar.Domain.Entities;

public class User
{
    public long Id { get; private set; }
    public string FirstName { get; private set; } = null!;
    public string LastName { get; private set; } = null!;
    public string PhoneNumber { get; private set; } = null!;
    public string PasswordHash { get; private set; } = null!;
    public string? Email { get; private set; }
    public DateTimeOffset CreatedAt { get; private set; }
    public IEnumerable<RefreshToken> RefreshTokens { get; private set; } = null!;

    private User()
    {
        
    }

    public User(string firstName, string lastName, string phoneNumber, string password)
    {
        FirstName = firstName;
        LastName = lastName;
        PhoneNumber = phoneNumber;
        PasswordHash = password;
        CreatedAt = DateTimeOffset.UtcNow;
    }

    public void SetEmail(string? email = null)
    {
        Email = email ?? null;
    }

    public void UpdateUser(string firstName, string lastName, string phoneNumber, string password)
    {
        FirstName = firstName;
        LastName = lastName;
        PhoneNumber = phoneNumber;
        PasswordHash = password;
    }
}
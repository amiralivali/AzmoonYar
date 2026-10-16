using AzmoonYar.Domain.Enums;

namespace AzmoonYar.Domain.Entities;

public class User
{
    public long Id { get; private set; }
    public string FirstName { get; private set; } = null!;
    public string LastName { get; private set; } = null!;
    public string? PhoneNumber { get; private set; }
    public string? PasswordHash { get; private set; }
    public string? GoogleId { get; private set; }
    public string? Email { get; private set; }
    public DateTimeOffset CreatedAt { get; private set; }
    public UserRole UserRole { get; private set; }
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
        UserRole = UserRole.User;
    }
 
    public static User CreateFromGoogle(string firstName, string lastName, string email, string googleId)
    {
        return new User
        {
            FirstName = firstName,
            LastName = lastName,
            Email = email,
            GoogleId = googleId,
            CreatedAt = DateTimeOffset.UtcNow,
            UserRole = UserRole.User
        };
    }
 
    public void LinkGoogle(string googleId)
    {
        GoogleId = googleId;
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
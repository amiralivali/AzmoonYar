namespace AzmoonYar.Domain.Entities;

public class User
{
    public long Id { get; private set; }
    public string FirstName { get; private set; } = null!;
    public string LastName { get; private set; } = null!;
    public string PhoneNumber { get; private set; } = null!;
    public string Password { get; private set; } = null!;
    public string? Email { get; private set; }
    public DateTimeOffset CreatedAt { get; private set; }

    private User()
    {
        
    }

    public User(string firstName, string lastName, string phoneNumber, string password)
    {
        FirstName = firstName;
        LastName = lastName;
        PhoneNumber = phoneNumber;
        Password = password;
        CreatedAt = DateTimeOffset.UtcNow;
    }

    public void SetEmail(string email)
    {
        Email = email;
    }

    public void UpdateUser(string firstName, string lastName, string phoneNumber, string password)
    {
        FirstName = firstName;
        LastName = lastName;
        PhoneNumber = phoneNumber;
        Password = password;
    }
}
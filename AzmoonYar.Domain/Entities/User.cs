namespace AzmoonYar.Domain.Entities;

public class User
{
    public long Id { get; private set; }
    public string FirstName { get; private set; } = null!;
    public string LastName { get; private set; } = null!;
    public string? UserName { get; private set; } 
    public string? Password { get; private set; }
    public string PhoneNumber { get; private set; } = null!;
    public DateTimeOffset CreatedAt { get; set; }

    private User()
    {
        
    }

    public User(string firstName, string lastName, string phoneNumber)
    {
        FirstName = firstName;
        LastName = lastName;
        PhoneNumber = phoneNumber;
        CreatedAt = DateTimeOffset.UtcNow;
    }

    public void SetCredentials(string userName, string password)
    {
        UserName = userName;
        Password = password;
    }
}
using System.ComponentModel;

namespace AzmoonYar.API.Models;

public class User
{
    public User(Guid guid, string username, string password)
    {
        Guid = guid;
        Username = username;
        Password = password;
    }

    public Guid Guid { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
}
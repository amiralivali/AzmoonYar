using AzmoonYar.API.Intefaces;
using AzmoonYar.API.Models;

namespace AzmoonYar.API.Services;

public class AuthService:IAuthService
{
    public static List<User> Users = new List<User>();
    public Guid Login(User user)
    {
        var check = Users.Find(x => x.Username == user.Username && x.Password == user.Password);
        if (check != null)
        {
            return check.Guid;
        }
        else
        {
            return Guid.Empty;
        }
    }

    public bool Register(User user)
    {
        if (Users.Find(x=>x.Username==user.Username && x.Password==user.Password)==null)
        {
            var guid = Guid.NewGuid();
            user.Guid = guid;
            Users.Add(user);
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool IsValid(Guid guid)
    {
        foreach (var user in Users)
        {
            if (user.Guid == guid)
            {
                return true;
            }
        }
        return false;
    }
}
using AzmoonYar.API.Models;

namespace AzmoonYar.API.Intefaces;

public interface IAuthService
{
    public Guid Login(User user);
    public bool Register(User user);
    public bool IsValid(Guid guid);
}
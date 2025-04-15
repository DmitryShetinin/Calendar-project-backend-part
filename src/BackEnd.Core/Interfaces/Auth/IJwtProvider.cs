using BackEnd.Models;

namespace BackEnd.Interfaces.Auth;
public interface IJwtProvider
{
    string GenerateToken(User user);

}
using UsersApi.Models;

namespace UsersApi.Services;
public interface IJwtService
{
    string GenerateToken(User user);
}
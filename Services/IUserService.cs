using UsersApi.Models;

namespace UsersApi.Services;

public interface IUserService
{
    Task<List<User>> GetAllAsync();
    Task<User?> GetByIdAsync(int id);
    Task<User> CreateAsync(string name, Role role);
    Task<User?> UpdateAsync(int id, string? name, Role? role);
    Task<bool> DeleteAsync(int id);
}
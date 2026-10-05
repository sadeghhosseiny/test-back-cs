using UsersApi.Dtos;
using UsersApi.Models;

namespace UsersApi.Services;

public interface IUserService
{
    Task<List<User>> GetAllAsync();
    Task<UserResponse?> GetByIdAsync(int id);
    Task<User> CreateAsync(User user);
    Task<bool> UpdateAsync(int id, UpdateUserRequest request);
    Task<bool> DeleteAsync(int id);
}
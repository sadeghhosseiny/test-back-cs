using UsersApi.Dtos;
using UsersApi.Models;

namespace UsersApi.Services;

public interface IUserService
{
    Task<List<UserResponse>> GetAllAsync(int pageNumber, int pageSize, string? searchName, Role? role);
    Task<UserResponse?> GetByIdAsync(int id);
    Task<User> CreateAsync(User user);
    Task<bool> UpdateAsync(int id, UpdateUserRequest request);
    Task<bool> DeleteAsync(int id);
}
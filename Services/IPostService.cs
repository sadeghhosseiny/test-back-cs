using UsersApi.Dtos;
using UsersApi.Models;

namespace UsersApi.Services;

public interface IPostService
{
    Task<Post?> CreateAsync(string title, string? content, int userId);
    Task<bool> UpdateAsync(int id, UpdatePostRequest request);

}
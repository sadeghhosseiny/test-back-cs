// Services/UserService.cs
using Microsoft.EntityFrameworkCore;
using UsersApi.Data;
using UsersApi.Dtos;
using UsersApi.Models;

namespace UsersApi.Services;

public class UserService : IUserService
{
    private readonly AppDbContext _db;

    public UserService(AppDbContext db)
    {
        _db = db;
    }

    public async Task<List<User>> GetAllAsync()
    {
        return await _db.Users.ToListAsync();
    }

    public async Task<UserResponse?> GetByIdAsync(int id)
    {
        var user = await _db.Users
            .Include(u => u.Posts)
            .FirstOrDefaultAsync(u => u.Id == id);

        if (user == null) return null;

        return new UserResponse(
            user.Id,
            user.Name,
            user.Role.ToString(),
            user.Posts.Select(p => new PostResponse(
                p.Id,
                p.Title,
                p.Content,
                p.CreatedAt
            )).ToList()
        );
    }

    public async Task<User> CreateAsync(User user)
    {
        _db.Users.Add(user);
        await _db.SaveChangesAsync();
        return user;
    }

    public async Task<bool> UpdateAsync(int id, UpdateUserRequest request)
    {
        var user = await _db.Users.FindAsync(id);
        if (user == null) return false;

        if (request.Name != null) user.Name = request.Name;
        if (request.Role != null) user.Role = request.Role.Value;

        await _db.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var user = await _db.Users.FindAsync(id);
        if (user == null) return false;

        _db.Users.Remove(user);
        await _db.SaveChangesAsync();
        return true;
    }
}
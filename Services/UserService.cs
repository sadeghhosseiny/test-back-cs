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

    public async Task<List<UserResponse>> GetAllAsync(int pageNumber, int pageSize, string? searchName, Role? role)
    {
        var query = _db.Users.Include(u => u.Posts).AsQueryable();

        if (!string.IsNullOrWhiteSpace(searchName))
        {
            query = query.Where(u => u.Name.Contains(searchName));
        }

        if (role.HasValue)
        {
            query = query.Where(u => u.Role == role.Value);
        }

        var users = await query
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();

        return users.Select(u => new UserResponse(
            u.Id,
            u.Name,
            u.Role.ToString(),
            u.Posts.Select(p => new PostResponse(p.Id, p.Title, p.Content, p.CreatedAt)).ToList()
        )).ToList();
    }

    public async Task<UserResponse?> GetByIdAsync(int id)
    {
        var user = await _db.Users
            .Include(u => u.Posts)
            .FirstOrDefaultAsync(u => u.Id == id);

        if (user == null) throw new KeyNotFoundException("User with this ID was not found.");

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
using Microsoft.EntityFrameworkCore;
using UsersApi.Data;
using UsersApi.Models;

namespace UsersApi.Services;

public class UserService : IUserService
{
    private readonly AppDbContext _db;

    public UserService(AppDbContext db)
    {
        _db = db;
    }

    public Task<List<User>> GetAllAsync()
    {
        return _db.Users.OrderBy(u => u.Id).ToListAsync();
    }

    public Task<User?> GetByIdAsync(int id)
    {
        return _db.Users
            .Include(u => u.Posts)
            .FirstOrDefaultAsync(u => u.Id == id);
    }

    public async Task<User> CreateAsync(string name, Role role)
    {
        var user = new User { Name = name, Role = role };
        _db.Users.Add(user);
        await _db.SaveChangesAsync();
        return user;
    }

    public async Task<User?> UpdateAsync(int id, string? name, Role? role)
    {
        var user = await _db.Users.FindAsync(id);

        if (user is null)
        {
            return null;
        }

        if (name is not null) user.Name = name;
        if (role is not null) user.Role = role.Value;

        await _db.SaveChangesAsync();
        return user;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var user = await _db.Users.FindAsync(id);

        if (user is null)
        {
            return false;
        }

        _db.Users.Remove(user);
        await _db.SaveChangesAsync();
        return true;
    }
}
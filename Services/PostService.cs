using Microsoft.EntityFrameworkCore;
using UsersApi.Data;
using UsersApi.Models;

namespace UsersApi.Services;

public class PostService : IPostService
{
    private readonly AppDbContext _db;

    public PostService(AppDbContext db)
    {
        _db = db;
    }

    public async Task<Post?> CreateAsync(string title, string? content, int userId)
    {
        var userExists = await _db.Users.AnyAsync(u => u.Id == userId);

        if (!userExists)
        {
            return null;
        }

        var post = new Post
        {
            Title = title,
            Content = content,
            UserId = userId,
        };

        _db.Posts.Add(post);
        await _db.SaveChangesAsync();
        return post;
    }
}
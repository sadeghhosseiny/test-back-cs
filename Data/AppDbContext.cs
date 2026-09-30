// Data/AppDbContext.cs
using Microsoft.EntityFrameworkCore;
using UsersApi.Models;

namespace UsersApi.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<User> Users => Set<User>();
    public DbSet<Post> Posts => Set<Post>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>(entity =>
        {
            entity.Property(u => u.Name).HasMaxLength(50);

            entity.Property(u => u.Role)
                .HasConversion<string>()
                .HasMaxLength(20);
        });

        modelBuilder.Entity<Post>(entity =>
        {
            entity.Property(p => p.Title).HasMaxLength(200);

            entity.Property(p => p.CreatedAt)
                .HasDefaultValueSql("now()");

            entity.HasOne(p => p.User)
                .WithMany(u => u.Posts)
                .HasForeignKey(p => p.UserId)
                .OnDelete(DeleteBehavior.Restrict);
        });
    }
}
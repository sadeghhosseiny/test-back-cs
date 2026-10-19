namespace UsersApi.Models;

public class User
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;
    public Role Role { get; set; } = Role.User;
    public List<Post> Posts { get; set; } = new List<Post>();
}
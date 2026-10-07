using UsersApi.Models;
namespace UsersApi.Dtos;

public record CreateUserRequest(
    string Name,
    Role? Role
);
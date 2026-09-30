using System.ComponentModel.DataAnnotations;
using UsersApi.Models;

namespace UsersApi.Dtos;

public record CreateUserRequest(
    [Required, StringLength(50, MinimumLength = 1)] string Name,
    [Required, EnumDataType(typeof(Role))] Role? Role
);
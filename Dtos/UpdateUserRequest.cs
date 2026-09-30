using System.ComponentModel.DataAnnotations;
using UsersApi.Models;

namespace UsersApi.Dtos;

public record UpdateUserRequest(
    [StringLength(50, MinimumLength = 1)] string? Name,
    [EnumDataType(typeof(Role))] Role? Role
);
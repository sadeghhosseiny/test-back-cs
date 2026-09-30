using System.ComponentModel.DataAnnotations;

namespace UsersApi.Dtos;

public record CreatePostRequest(
    [Required, StringLength(200, MinimumLength = 1)] string Title,
    string? Content,
    [Required] int? UserId
);
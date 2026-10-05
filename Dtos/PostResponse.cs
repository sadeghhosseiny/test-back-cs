namespace UsersApi.Dtos;

public record PostResponse(
    int Id,
    string Title,
    string? Content,
    DateTime CreatedAt
);
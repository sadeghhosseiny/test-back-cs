namespace UsersApi.Dtos;

public record CreatePostRequest(
    string Title,
    string? Content,
    int? UserId
);

public record UpdatePostRequest(
    string Title,
    string? Content
);
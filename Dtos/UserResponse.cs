namespace UsersApi.Dtos;

public record UserResponse(
    int Id,
    string Name,
    string Role,
    List<PostResponse> Posts
);
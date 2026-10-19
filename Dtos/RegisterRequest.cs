namespace UsersApi.Dtos;

public record RegisterRequest(
    string Name,
    string PhoneNumber
);
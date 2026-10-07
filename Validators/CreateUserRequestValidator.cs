using FluentValidation;
using UsersApi.Dtos;

namespace UsersApi.Validators;

public class CreateUserRequestValidator : AbstractValidator<CreateUserRequest>
{
    public CreateUserRequestValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("نام کاربر الزامی است.")
            .Length(2, 50).WithMessage("نام باید بین ۲ تا ۵۰ کاراکتر باشد.");
    }
}
using FluentValidation;
using UsersApi.Dtos;

namespace UsersApi.Validators;

public class CreatePostRequestValidator : AbstractValidator<CreatePostRequest>
{
    public CreatePostRequestValidator()
    {
        RuleFor(x => x.Title)
            .NotEmpty().WithMessage("عنوان پست الزامی است.")
            .Length(3, 200).WithMessage("عنوان پست باید بین ۳ تا ۲۰۰ کاراکتر باشد.");

        RuleFor(x => x.Content)
            .MaximumLength(2000).WithMessage("متن پست نمی‌تواند بیشتر از ۲۰۰۰ کاراکتر باشد.");

        RuleFor(x => x.UserId)
            .GreaterThan(0).WithMessage("شناسه کاربر معتبر نیست.");
    }
}
using FluentValidation;

namespace YoutubeApi.Application.Features.Auth.Command.Register;

public class RegisterCommandValidator : AbstractValidator<RegisterCommandRequest>
{
    public RegisterCommandValidator()
    {
        RuleFor(x => x.Name).NotEmpty().MaximumLength(60).MinimumLength(2);
        RuleFor(x => x.Surname).NotEmpty().MaximumLength(60).MinimumLength(2);
        RuleFor(x => x.Fullname).NotEmpty().MaximumLength(120).MinimumLength(2);
        RuleFor(x => x.Email).NotEmpty().EmailAddress().MaximumLength(60).MinimumLength(8);
        RuleFor(x => x.Password).NotEmpty().MinimumLength(6);
        RuleFor(x => x.ConfirmPassword).NotEmpty().MinimumLength(6).Equal(x => x.Password);
    }
}

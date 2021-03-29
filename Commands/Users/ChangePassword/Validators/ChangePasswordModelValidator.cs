using FluentValidation;
using WebApi.Commands.Users.ChangePassword.Models;


namespace WebApi.Commands.Users.ChangePassword.Validators
{
    public class ChangePasswordModelValidator : AbstractValidator<ChangePasswordModel>
    {
        public ChangePasswordModelValidator()
        {
            CascadeMode = CascadeMode.StopOnFirstFailure;

            RuleFor(x => x.Password)
                    .NotEmpty();

            RuleFor(x => x.NewPassword)
                    .NotEmpty();
            

        }
    }
}

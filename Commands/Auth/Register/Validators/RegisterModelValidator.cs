using FluentValidation;
using Microsoft.EntityFrameworkCore;
using WebApi.Commands.Auth.Register.Models;
using WebApi.Common;
using WebApi.Helpers;

namespace WebApi.Commands.Auth.Register.Validators
{
    public class RegisterModelValidator : AbstractValidator<RegisterModel>
    {
        public RegisterModelValidator(DataContext dataContext)
        {
            CascadeMode = CascadeMode.StopOnFirstFailure;

            RuleFor(x => x.FirstName)
                    .NotEmpty();

            RuleFor(x => x.LastName)
                    .NotEmpty();

            RuleFor(x => x.Username)
                    .NotEmpty()
                    .Must((username) => ValidatorUtil.IsValidEmail(username))
                    .WithMessage("Username must be an email")
                    .MustAsync(async (username, ct) =>
                    {
                        var user = await dataContext.Users.FirstOrDefaultAsync(u => u.Username == username);
                        return user == null || !user.IsActivated;
                    }).WithMessage("This username is already taken");

            RuleFor(x => x.Password)
                    .NotEmpty();
        }
    }
}

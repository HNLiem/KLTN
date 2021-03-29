using FluentValidation;
using Microsoft.EntityFrameworkCore;
using WebApi.Common;
using WebApi.Helpers;

namespace WebApi.Commands.Auth.Login.Validators
{
    public class LoginValidator : AbstractValidator<Login>
    {
        public LoginValidator(DataContext dataContext)
        {
            CascadeMode = CascadeMode.StopOnFirstFailure;

            RuleFor(x => x.Model.Username)
                .MustAsync((username, token) => dataContext.Users.AnyAsync(u => u.Username == username, token))
                .WithMessage("User not found")
                .MustAsync((username, token) => dataContext.Users.AnyAsync(u => u.Username == username && u.IsActivated))
                .WithMessage("Account is not activated");

            RuleFor(x => x.Model.Password)
                .MustAsync(async (request, password, token) =>
                {
                    var user = await dataContext.Users.FirstOrDefaultAsync(u => u.Username == request.Model.Username);

                    return user != null && PasswordUtil.VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt);
                })
                .WithMessage("Username or password is incorrect");

        }
             
    }
}

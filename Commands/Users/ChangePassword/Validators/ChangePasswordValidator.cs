using FluentValidation;
using Microsoft.EntityFrameworkCore;
using WebApi.Common;
using WebApi.Helpers;

namespace WebApi.Commands.Users.ChangePassword.Validators
{
    public class ChangePasswordValidator : AbstractValidator<ChangePassword>
    {
        public ChangePasswordValidator(DataContext context)
        {
            CascadeMode = CascadeMode.StopOnFirstFailure;

            RuleFor(x => x.Id)
                .MustAsync((id, token) => context.Users.AnyAsync(u => u.Id == id, token))
                .WithMessage("User not found");

            RuleFor(x => x.Model.Password)
                .MustAsync(async (request, password, token) =>
                {
                    var user = await context.Users.FirstOrDefaultAsync(u => u.Id == request.Id);

                    return user != null && PasswordUtil.VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt);
                })
                .WithMessage("Username or password is incorrect");
        }
    }
}

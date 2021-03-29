using WebApi.Helpers;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace WebApi.Commands.Users.UpdateSasAvatar.Validator
{
    public class UpdateSasAvatarCommandValidator : AbstractValidator<UpdateSasAvatarCommand>
    {
        public UpdateSasAvatarCommandValidator(DataContext dataContext)
        {
            CascadeMode = CascadeMode.StopOnFirstFailure;

            RuleFor(x => x.UserId)
                     .NotEmpty()
                     .MustAsync((UserId, ct) => dataContext.Users.AnyAsync(u => u.Id == UserId))
                     .WithMessage("User not Found");
        }
    }
}

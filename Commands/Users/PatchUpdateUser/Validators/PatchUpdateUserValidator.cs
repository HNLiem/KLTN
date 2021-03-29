using FluentValidation;
using Microsoft.EntityFrameworkCore;
using WebApi.Helpers;

namespace WebApi.Commands.Users.PatchUpdateUser.Validators
{
    public class PatchUpdateUserValidator : AbstractValidator<PatchUpdateUser>
    {
        public PatchUpdateUserValidator(DataContext dataContext)
        {
            CascadeMode = CascadeMode.StopOnFirstFailure;

            RuleFor(x => x.Id)
                         .NotEmpty()
                         .MustAsync((id, ct) => dataContext.Users.AnyAsync(u => u.Id == id))
                         .WithMessage("User Not Found");
        }
    }
}

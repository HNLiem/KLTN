using FluentValidation;
using Microsoft.EntityFrameworkCore;
using WebApi.Helpers;

namespace WebApi.Queries.Users.GetUserById.Validators
{
    public class GetUserByIdValidator : AbstractValidator<GetUserById>
    {
        public GetUserByIdValidator(DataContext dataContext)
        {
            CascadeMode = CascadeMode.StopOnFirstFailure;

            RuleFor(x => x.Id)
                     .NotEmpty()
                     .MustAsync((id, ct) => dataContext.Users.AnyAsync(u => u.Id == id))
                     .WithMessage("User not Found");
        }
    }
}

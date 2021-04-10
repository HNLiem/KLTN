using FluentValidation;
using Microsoft.EntityFrameworkCore;
using WebApi.Helpers;

namespace WebApi.Queries.Order.GetOrderByAdmin.Validators
{
    public class GetOrderByAdminQueryValidator : AbstractValidator<GetOrderByAdminQuery>
    {
        public GetOrderByAdminQueryValidator(DataContext dataContext)
        {
            CascadeMode = CascadeMode.StopOnFirstFailure;

            RuleFor(x => x.Id)
                     .NotEmpty()
                     .MustAsync((id, ct) => dataContext.Users.AnyAsync(u => u.Id == id))
                     .WithMessage("User not Found");
        }
    }
}

using FluentValidation;
using Microsoft.EntityFrameworkCore;
using WebApi.Helpers;

namespace WebApi.Commands.Employees.InsertEmployee.Validator
{
    public class InsertEmployeeCommandValidator : AbstractValidator<InsertEmployeeCommand>
    {
        public InsertEmployeeCommandValidator(DataContext _context)
        {
            CascadeMode = CascadeMode.StopOnFirstFailure;

            RuleFor(x => x.Model.Address)
                    .NotEmpty()
                    .WithMessage("Address must be an email");

            RuleFor(x => x.Model.BirthDate)
                    .NotEmpty()
                    .WithMessage("Birth date must be an email");

            RuleFor(x => x.Model.Name)
                    .NotEmpty()
                    .WithMessage("Name must be an email");

            RuleFor(x => x.Model.PhoneNumber)
                    .NotEmpty()
                    .WithMessage("Phone number must be an email");

            RuleFor(x => x.Id)
                     .NotEmpty()
                     .MustAsync((id, ct) => _context.Users.AnyAsync(u => u.Id == id))
                     .WithMessage("User not Found");

            RuleFor(x => x.Model.UserName)
                     .NotEmpty()
                     .MustAsync((UserName, ct) => _context.Employees.AnyAsync(u => u.UserName != UserName))
                     .WithMessage("UserName exists");

        }
    }
}

using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Helpers;

namespace WebApi.Commands.Orders.UpdateSatus.Validator
{
    public class UpdateOrderStatusCommandValidator : AbstractValidator<UpdateOrderStatusCommand>
    {
        public UpdateOrderStatusCommandValidator(DataContext _context)
        {
            CascadeMode = CascadeMode.StopOnFirstFailure;

            RuleFor(x => x.UserId)
                     .NotEmpty()
                     .MustAsync((id, ct) => _context.Users.AnyAsync(u => u.Id == id))
                     .WithMessage("User not Found");

            RuleFor(x => x.OrderId)
                     .NotEmpty()
                     .MustAsync((id, ct) => _context.Orders.AnyAsync(u => u.Id == id))
                     .WithMessage("Order not Found");

            RuleFor(x => x.Status)
                     .NotEmpty()                    
                     .WithMessage("Status must not empty");

            /*
             check validator don hang co thuoc quan ly cua admin
             */
        }
    }
}

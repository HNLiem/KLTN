using FluentValidation;
using WebApi.Commands.Users.UpdateUser.Models;
using WebApi.Common;

namespace WebApi.Commands.Users.UpdateUser.Validators
{
    public class UpdateUserModelValidator : AbstractValidator<UpdateUserModel>
    {
        public UpdateUserModelValidator()
        {
            CascadeMode = CascadeMode.StopOnFirstFailure;

            RuleFor(x => x.FirstName)
                    .NotEmpty();

            RuleFor(x => x.LastName)
                    .NotEmpty();

            RuleFor(x => x.Email)
                    .NotEmpty()
                    .Must((email) => ValidatorUtil.IsValidEmail(email))
                    .WithMessage("Email is incorrect");

            RuleFor(x => x.BirthDate)
                    .NotEmpty();

            RuleFor(x => x.Address)
                    .NotEmpty();

            RuleFor(x => x.UserPhoneNumbers)
                    .NotEmpty();
                            
        }
    }
}

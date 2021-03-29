using FluentValidation;
using WebApi.Commands.Users.Models.PatchUpdateUser;
using WebApi.Common;

namespace WebApi.Commands.Users.PatchUpdateUser.Validators
{
    public class PatchUpdateUserModelValidator : AbstractValidator<PatchUpdateUserModel>
    {
        PatchUpdateUserModelValidator()
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

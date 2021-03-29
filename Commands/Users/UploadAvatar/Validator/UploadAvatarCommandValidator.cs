using FluentValidation;
using Microsoft.EntityFrameworkCore;
using WebApi.Commands.Users.CrateAvatar;
using WebApi.Helpers;

namespace WebApi.Commands.Users.UploadAvatar.Validator
{
    public class UploadAvatarCommandValidator : AbstractValidator<UploadAvatarCommand>
    {
        public UploadAvatarCommandValidator(DataContext context)
        {
            CascadeMode = CascadeMode.StopOnFirstFailure;

            RuleFor(x => x.UserId)
                .MustAsync((userId, token) => context.Users.AnyAsync(u => u.Id == userId, token))
                .WithMessage("User not found");

            RuleFor(x => x.FormFile)
                   .NotEmpty()
                   .Must((formFile) => ValidatorImage.CheckImage(formFile))
                   .WithMessage("This file is not supported");

        }
    }
}

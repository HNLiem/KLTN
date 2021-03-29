using FluentValidation;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Commands.Auth.Login.Models;
using WebApi.Common;
using WebApi.Helpers;

namespace WebApi.Commands.Auth.Login.Validators
{
    public class LoginModelValidator : AbstractValidator<LoginModel>
    {
        public LoginModelValidator()
        {
            CascadeMode = CascadeMode.StopOnFirstFailure;

            RuleFor(x => x.Username)
                    .NotEmpty()
                    .Must((username) => ValidatorUtil.IsValidEmail(username))
                    .WithMessage("Username must be an email");

            RuleFor(x => x.Password)
                    .NotEmpty();

        }
    }
}

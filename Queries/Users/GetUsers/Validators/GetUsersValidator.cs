using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Helpers;

namespace WebApi.Queries.Users.GetUsers.Validators
{
    public class GetUsersValidator : AbstractValidator<GetUsers>
    {
        public GetUsersValidator()
        {
            CascadeMode = CascadeMode.StopOnFirstFailure;

            RuleFor(x => x.PaginationParameters.PageNumber)
                    .GreaterThan(0);

            RuleFor(x => x.PaginationParameters.PageSize)
                    .GreaterThan(0);

            
        }
    }
}

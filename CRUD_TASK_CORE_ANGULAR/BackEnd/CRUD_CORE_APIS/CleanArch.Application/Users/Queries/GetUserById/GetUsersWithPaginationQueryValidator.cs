using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;

namespace CleanArch.Application.Users.Queries.GetUsersWithPagination
{
    public class GetUserByIdQueryValidator : AbstractValidator<GetUserByIdQuery>
    {
        public GetUserByIdQueryValidator()
        {
            RuleFor(x => x.UserId)
                .GreaterThan(0).WithMessage("User Id Required");
        }
    }

}

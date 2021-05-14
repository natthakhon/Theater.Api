using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using Theater.CQRS.User.Query;

namespace Theater.CQRS.Validator.User
{
    public class GetUserByUserNameValidator : AbstractValidator<GetUserByUserName>
    {
        public GetUserByUserNameValidator()
        {
            RuleFor(p => p.UserName)
                .NotEmpty()
                .WithMessage("Username must not be empty");

            RuleFor(p => p.Password)
                .NotEmpty()
                .WithMessage("Password must not be empty");
        }
    }
}

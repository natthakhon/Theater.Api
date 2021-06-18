using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using dom = Theater.Domain.User;

namespace Theater.Domain.Validator.User
{
    public class LoginValidator : AbstractValidator<dom.Login>
    {
        public LoginValidator(IUserChecker userChecker)
        {
            RuleFor(p => p.User)
                .NotNull()
                .WithMessage("User cannot be null");

            RuleFor(p =>p)
                .Must(p => userChecker.IsUserExisted(p.User.UserName).Result)
                .WithMessage("User is not existed");
        }
    }
}

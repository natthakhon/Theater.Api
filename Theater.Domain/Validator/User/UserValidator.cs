﻿using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using U = Theater.Domain.User;

namespace Theater.Domain.Validator.User
{
    public class UserValidator : AbstractValidator<U.User>
    {
        public UserValidator(IUserChecker userChecker)
        {
            //email validation
            RuleFor(p => p.EMail)
                .NotEmpty()
                .WithMessage("Email must not be empty");
            RuleFor(p => p.EMail)
                .EmailAddress()
                .WithMessage("Email is not in correct format");
            RuleFor(p => p.EMail)
                .Must(email => !userChecker.IsEmailExisted(email).Result)
                .WithMessage("Email is already existed");

            RuleFor(p => p.Phone)
                .Matches(@"^$|^\d{10}$")
                .WithMessage("Phone is not in correct format");

            //password validation
            RuleFor(p => p.Password)
                .Matches(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*[0-9])(?=.*[!@#\$%\^&\*])(?=.{8,})")
                .WithMessage("Password must contain at least 1 lower character, 1 number, 1 special character, 1 capital with at least 8 characters length");

            //user validation
            RuleFor(p => p.UserName)
                .NotEmpty()
                .WithMessage("User must not be empty");
            RuleFor(p => p.UserName)
                .MaximumLength(25)
                .WithMessage("User must not exceed 25 characters");
            RuleFor(p => p.UserName)
                .Must(user => !userChecker.IsUserExisted(user).Result)
                .WithMessage("User is already existed");
        }
    }
}

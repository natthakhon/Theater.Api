using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using U = Theater.Domain.User;

namespace Theater.Domain.Validator.User
{
    public class UserValidator : AbstractValidator<U.User>
    {
        public UserValidator()
        {
            //name validation
            RuleFor(p => p.Name)
                .NotEmpty()
                .WithMessage("Name must not be empty");
            RuleFor(p => p.Name)
                .MaximumLength(25)
                .WithMessage("Name must not exceed 25 characters");

            //lastname validation
            RuleFor(p => p.LastName)
                .NotEmpty()
                .WithMessage("LastName must not be empty");
            RuleFor(p => p.Name)
                .MaximumLength(25)
                .WithMessage("LastName must not exceed 25 characters");

            //email validation
            RuleFor(p => p.EMail)
                .NotEmpty()
                .WithMessage("Email must not be empty");
            RuleFor(p => p.EMail)
                .EmailAddress()
                .WithMessage("Email is not in correct format");

            //cellphone validation
            RuleFor(p => p.Phone)
                .NotEmpty()
                .WithMessage("Cell phone must not be empty");
            RuleFor(p => p.Phone)
                .Matches(@"^\d{10}$")
                .WithMessage("Phone is not in correct format");
                


            //password validation
            //10 len
            //at least 1 special char
            //at least 1 number
            //at least 1 capital case
            RuleFor(p => p.Password)
                .Matches("^(?=.*[A-Z])(?=.*[!@#$&*])(?=.*[0-9])(?=.*[a-z].*[a-z].*[a-z]).{10}$")
                .WithMessage("Password must contain at least 1 number, 1 special character, 1 capital with total of 10 character length");


        }
    }
}

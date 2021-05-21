using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using Theater.CQRS.User.Query;
using U = Theater.Domain.User;

namespace Theater.CQRS.Validator.User
{
    public class GetUserByEmailValidator : AbstractValidator<GetUserByEmail>  
    {
        public GetUserByEmailValidator()
        {
            RuleFor(p=>p.Email)
                .NotEmpty()
                .WithMessage("Email must not be empty");

            RuleFor(p => p.Password)
                .NotEmpty()
                .WithMessage("Password must not be empty");
        }
    }
}

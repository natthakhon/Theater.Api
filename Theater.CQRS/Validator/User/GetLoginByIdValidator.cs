using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using Theater.CQRS.User.Query;

namespace Theater.CQRS.Validator.User
{
    public class GetLoginByIdValidator : AbstractValidator<GetLoginById>
    {
        public GetLoginByIdValidator()
        {
            RuleFor(p => p.Id)
                .NotEmpty()
                .WithMessage("Id must not be empty");
        }
    }
}

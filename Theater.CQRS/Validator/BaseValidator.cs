using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Theater.CQRS.Validator
{
    public class BaseValidator<T> : AbstractValidator<IRequest<T>>
        where T:class
    {
    }
}

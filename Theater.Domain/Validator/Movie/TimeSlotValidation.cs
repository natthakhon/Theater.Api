using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using M = Theater.Domain.Movie;

namespace Theater.Domain.Validator.Movie
{
    public class TimeSlotValidation : AbstractValidator<M.TimeSlot>
    {
        public TimeSlotValidation()
        {
            RuleFor(p => p.TimeStart)
                .NotEmpty()
                .WithMessage("Time Start must not be empty");
            RuleFor(p => p.TimeEnd)
                .NotEmpty()
                .WithMessage("Time End must not be empty");
        }
    }
}

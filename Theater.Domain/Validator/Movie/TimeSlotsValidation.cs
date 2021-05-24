using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using M = Theater.Domain.Movie;


namespace Theater.Domain.Validator.Movie
{
    public class TimeSlotsValidation : AbstractValidator<M.TimeSlots>
    {
        public TimeSlotsValidation(ITimeSlotsChecker timeSlotsChecker)
        {
            RuleFor(p => p.Name)
                .NotEmpty()
                .WithMessage("Time Start must not be empty");
            RuleFor(p => p.Name)
                .Must(name => !timeSlotsChecker.IsNameExisted(name).Result)
                .WithMessage("TimeSlot Name is already existed");

            RuleFor(p => p.Slots)
                .Must(slots => !timeSlotsChecker.AreSlotsExisted(slots).Result)
                .WithMessage("TimeSlots are already existed");
            RuleFor(p => p.Slots)
                .Must(slots => !(slots.Count == 0))
                .WithMessage("TimeSlots must not be empty");
        }
    }
}

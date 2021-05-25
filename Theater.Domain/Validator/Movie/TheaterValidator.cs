﻿using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using M = Theater.Domain.Movie;

namespace Theater.Domain.Validator.Movie
{
    public class TheaterValidator : AbstractValidator<M.Theater>
    {
        public TheaterValidator(ITheaterChecker theaterChecker)
        {
            RuleFor(p => p.Name)
                .NotEmpty()
                .WithMessage("Theater Name must not be empty");
            RuleFor(p => p.Name)
                .Must(name => !theaterChecker.IsTheaterExisted(name).Result)
                .WithMessage("Theater Name is already existed");
        }
    }
}
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using M = Theater.Domain.Movie;

namespace Theater.Domain.Validator.Movie
{
    public class MovieValidator : AbstractValidator<M.Movie>
    {
        public MovieValidator(IMovieChecker movieCheck)
        {
            RuleFor(p=>p.MovieName)
                .NotEmpty()
                .WithMessage("Movie Name must not be empty");
            RuleFor(p => p.MovieName)
                .Must(name => !movieCheck.IsMovieExisted(name).Result)
                .WithMessage("Movie is already existed");

            RuleFor(p => p.Length)
                .GreaterThanOrEqualTo(1)
                .WithMessage("Invalid length");
        }
    }
}

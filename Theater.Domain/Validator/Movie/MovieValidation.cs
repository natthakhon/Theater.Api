using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using M = Theater.Domain.Movie;

namespace Theater.Domain.Validator.Movie
{
    public class MovieValidation : AbstractValidator<M.Movie>
    {
        public MovieValidation(IMovieChecker movieCheck)
        {
            RuleFor(p=>p.MovieName)
                .NotEmpty()
                .WithMessage("Movie Name must not be empty");
            RuleFor(p => p.MovieName)
                .Must(name => !movieCheck.IsMovieExisted(name).Result)
                .WithMessage("Movie is already existed");
        }
    }
}

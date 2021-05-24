using System;
using System.Collections.Generic;
using System.Text;
using M = Theater.Domain.Movie;

namespace Theater.CQRS.Movie.Command
{
    public class CreateMovieCommand : IRequestor<M.Movie>
    {
        public M.Movie Item { get; set; }
    }
}

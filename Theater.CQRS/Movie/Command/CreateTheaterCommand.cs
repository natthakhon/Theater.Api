using System;
using System.Collections.Generic;
using System.Text;
using M = Theater.Domain.Movie;

namespace Theater.CQRS.Movie.Command
{
    public class CreateTheaterCommand : IRequestor<M.Theater>
    {
        public M.Theater Item { get; set; }
    }
}

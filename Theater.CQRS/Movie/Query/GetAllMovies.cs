using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using dom = Theater.Domain.Movie;

namespace Theater.CQRS.Movie.Query
{
    public class GetAllMovies : IRequest<List<dom.Movie>>
    {
    }
}

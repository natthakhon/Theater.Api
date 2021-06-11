using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Theater.Repository.Movie;
using Theater.Repository.User;
using dom = Theater.Domain.Movie;

namespace Theater.CQRS.Movie.Query
{
    public class GetAllMoviesHandler : BaseGetCommandHandler<GetAllMovies, List<dom.Movie>>
    {
        public GetAllMoviesHandler(IMovieRepository movieRepository) : base(movieRepository) { }

        protected override async Task<List<dom.Movie>> handle(GetAllMovies request, CancellationToken cancellationToken)
        {
            return await this.getrepository.GetAll();
        }
    }
}

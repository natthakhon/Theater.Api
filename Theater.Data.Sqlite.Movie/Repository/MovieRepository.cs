using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Theater.Repository.Movie;

namespace Theater.Data.Sqlite.Movie.Repository
{
    public class MovieRepository : IMovieRepository
    {
        public Task<Domain.Movie.Movie> CreateAsync(Domain.Movie.Movie model)
        {
            throw new NotImplementedException();
        }

        public Task<bool> IsMovieExisted(string email)
        {
            throw new NotImplementedException();
        }

        public Task<Domain.Movie.Movie> UpdateAsync(Domain.Movie.Movie model)
        {
            throw new NotImplementedException();
        }
    }
}

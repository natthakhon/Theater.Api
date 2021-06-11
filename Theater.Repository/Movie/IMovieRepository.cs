using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Theater.Domain.Validator.Movie;
using M = Theater.Domain.Movie;

namespace Theater.Repository.Movie
{
    public interface IMovieRepository : IGenericRepository<M.Movie>, IMovieChecker, IGetData<List<M.Movie>>
    {
        Task<List<M.Movie>> GetMovies(string movie);
    }
}

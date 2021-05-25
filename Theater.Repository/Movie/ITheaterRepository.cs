using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Theater.Domain.Validator.Movie;
using M = Theater.Domain.Movie;

namespace Theater.Repository.Movie
{
    public interface ITheaterRepository : IGenericRepository<M.Theater>, ITheaterChecker
    {
        Task<List<M.Theater>> GetTheaters(string theater);
    }
}

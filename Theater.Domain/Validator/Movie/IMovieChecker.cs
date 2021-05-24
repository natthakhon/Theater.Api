using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Theater.Domain.Validator.Movie
{
    public interface IMovieChecker
    {
        Task<bool> IsMovieExisted(string movie);
    }
}

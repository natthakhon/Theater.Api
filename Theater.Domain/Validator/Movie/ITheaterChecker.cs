using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Theater.Domain.Validator.Movie
{
    public interface ITheaterChecker
    {
        Task<bool> IsTheaterExisted(string theater);
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Theater.Repository
{
    public interface IGetData<T> where T:class
    {
        Task<T> GetAll();
    }
}

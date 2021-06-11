using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Theater.Repository
{
    public interface IGenericRepository<TModel> 
        where TModel :class
    {
        Task<TModel> CreateAsync(TModel model);
        Task<TModel> UpdateAsync(TModel modify);
    }
}

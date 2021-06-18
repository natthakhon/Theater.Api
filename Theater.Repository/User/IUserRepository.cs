using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Theater.Domain.Validator.User;
using U = Theater.Domain.User;

namespace Theater.Repository.User
{
    public interface IUserRepository : IGenericRepository<U.User>, IUserChecker, IGetData<List<U.User>>
    {
        Task<U.User> GetUserByUserNameAsync(string username,string password);
        Task<U.User> GetUserByEMailAsync(string email,string password);
    }
}

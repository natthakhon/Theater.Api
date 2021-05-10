using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using U = Theater.Domain.User;

namespace Theater.Repository.User
{
    public interface IUserRepository : IGenericRepository<U.User>
    {
        Task<U.User> GetUserByUserNameAsync(string username,string password);
        Task<U.User> GetUserByEMailAsync(string email,string password);
    }
}

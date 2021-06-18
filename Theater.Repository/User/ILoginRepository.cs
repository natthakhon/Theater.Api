using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using dom = Theater.Domain.User;

namespace Theater.Repository.User
{
    public interface ILoginRepository : IGenericRepository<dom.Login>
    {
        Task<dom.Login> GetLoginById(string loginid);
    }
}

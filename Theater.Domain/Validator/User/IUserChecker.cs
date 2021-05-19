using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Theater.Domain.Validator.User
{
    public interface IUserChecker
    {
        Task<bool> IsEmailExisted(string email);
        Task<bool> IsUserExisted(string user);
    }
}

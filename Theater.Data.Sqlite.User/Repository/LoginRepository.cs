using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Theater.Data.Sqlite.User.Mapper;
using Theater.Repository.User;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Theater.Data.Sqlite.User.Repository
{
    public class LoginRepository : ILoginRepository
    {
        private UserContext userContext = new UserContext();

        public LoginRepository() { }

        public async Task<Domain.User.Login> CreateAsync(Domain.User.Login model)
        {
            if (model != null)
            {
                var user = await this.userContext.Users.FirstOrDefaultAsync(p => p.UserName == model.User.UserName);
                var login = new LoginDomtoDataMapper(model).Destination;
                login.User = user;
                await this.userContext.AddAsync(login);
                await this.userContext.SaveChangesAsync();
                return model;
            }
            throw new ArgumentException("Model is null");
        }

        public async Task<Domain.User.Login> GetLoginById(string loginid)
        {
            if (!string.IsNullOrEmpty(loginid))
            {
                var login = await this.userContext.Logins.FirstOrDefaultAsync(p => p.LoginId == loginid);
                return new LoginDatatoDomMapper(login).Destination;
            }
            throw new ArgumentException("loginid is null");
        }

        public Task<Domain.User.Login> UpdateAsync(Domain.User.Login modify)
        {
            throw new NotImplementedException();
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using Theater.Repository.User;
using Theater.Security;
using Theater.Data.Sqlite.User.Mapper;

namespace Theater.Data.Sqlite.User.Repository
{
    public class UserRepository : IUserRepository
    {
        private UserContext userContext = new UserContext();

        public UserRepository() { }

        public async Task<Domain.User.User> CreateAsync(Domain.User.User model)
        {
            if (model != null)
            {
                await this.userContext.AddAsync(new UserMapper(model).Destination);                
                await this.userContext.SaveChangesAsync();
                return model;
            }
            throw new ArgumentException("Model is null");
        }

        public async Task<Domain.User.User> GetUserByEMailAsync(string email, string password)
        {
            if (!string.IsNullOrEmpty(email) && !string.IsNullOrEmpty(password))
            {
                var user = await this.userContext.Users.FirstOrDefaultAsync(p => p.Email == email);
                if (user != null)
                {
                    Password pwd = new Password(password, user.Salt, user.Password);
                    if (pwd.IsValid)
                    {
                        return new UserDataMapper(user).Destination;
                    }
                }
                throw new InvalidOperationException("Not found");
            }
            throw new ArgumentException("Parameter cannot be empty");
        }

        public async Task<Domain.User.User> GetUserByUserNameAsync(string username, string password)
        {
            if (!string.IsNullOrEmpty(username) && !string.IsNullOrEmpty(password))
            {
                var user = await this.userContext.Users.FirstOrDefaultAsync(p => p.UserName == username);
                if (user != null)
                {
                    Password pwd = new Password(password, user.Salt, user.Password);
                    if (pwd.IsValid)
                    {
                        return new UserDataMapper(user).Destination;
                    }
                }
                throw new InvalidOperationException("Not found");
            }
            throw new ArgumentException("Parameter cannot be empty");
        }

        public async Task<bool> IsEmailExisted(string email)
        {
            var user = await this.userContext.Users.FirstOrDefaultAsync(p => p.Email == email);
            return user != null;
        }

        public async Task<bool> IsUserExisted(string username)
        {
            var user = await this.userContext.Users.FirstOrDefaultAsync(p => p.UserName == username);
            return user != null;
        }

        public Task<Domain.User.User> UpdateAsync(Domain.User.User modify)
        {
            throw new NotImplementedException();
        }
    }
}

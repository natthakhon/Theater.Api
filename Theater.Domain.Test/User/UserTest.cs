using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Theater.Repository.User;
using U = Theater.Domain.User;
using V = Theater.Domain.Validator;

namespace Theater.Domain.Test.User
{
    [TestClass]
    public class UserTest
    {
        
        [TestMethod]
        public void TestValidUser()
        {
            U.User user = new U.User
            {
                Name = "test",
                LastName = "test",
                EMail = "test@test.com",
                Id = 1,
                Password = "A1@aaaaaaa",
                Phone = "1234567890",
                UserName = "test"
            };
            var result = new V.User.UserValidator(new userrepo()).Validate(user);
            Assert.IsTrue(result.IsValid);
        }
    }

    class userrepo : IUserRepository
    {
        public Task<U.User> CreateAsync(U.User model)
        {
            throw new NotImplementedException();
        }

        public Task<U.User> GetUserByEMailAsync(string email, string password)
        {
            throw new NotImplementedException();
        }

        public Task<U.User> GetUserByUserNameAsync(string username, string password)
        {
            throw new NotImplementedException();
        }

        public Task<bool> IsEmailExisted(string email)
        {
            return Task.Run(()=>
            {
                return false;
            });
        }

        public Task<bool> IsUserExisted(string user)
        {
            return Task.Run(() =>
            {
                return false;
            });
        }

        public Task<U.User> UpdateAsync(U.User old, U.User modify)
        {
            throw new NotImplementedException();
        }
    }
}

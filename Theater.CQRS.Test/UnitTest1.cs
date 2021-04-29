using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Threading.Tasks;
using Theater.CQRS.User.Command;
using Theater.Domain.Validator.User;
using Theater.Repository.User;
using U = Theater.Domain.User;
using System.Linq;
using System.Threading;
using Theater.CQRS.User.Query;
using System;

namespace Theater.CQRS.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public async Task TestAddValidUser()
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

            UserValidator userValidator = new UserValidator();


            CreateUserCommand createUserCommand = new CreateUserCommand();
            createUserCommand.Item = user;

            UserRepo userRepo = new UserRepo();
            CreateUserCommandHandler createUserCommandHandler = new CreateUserCommandHandler(userValidator, userRepo);

            var addresult = await createUserCommandHandler.Handle(createUserCommand, new CancellationToken());

            GetUserByEmail getUserByEmail = new GetUserByEmail();
            getUserByEmail.Email = user.EMail;

            GetUserByEmailHandler getUserByEmailHandler = new GetUserByEmailHandler(userRepo);
            var getresult = await getUserByEmailHandler.Handle(getUserByEmail, new CancellationToken());
            Assert.AreEqual(getresult.EMail, user.EMail);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException),
                "Phone is not in correct format")]
        public async Task TestAddInValidUser()
        {
            U.User user = new U.User
            {
                Name = "test",
                LastName = "test",
                EMail = "test@test.com",
                Id = 1,
                Password = "A1@aaaaaaa",
                Phone = "123456789",
                UserName = "test"
            };

            UserValidator userValidator = new UserValidator();


            CreateUserCommand createUserCommand = new CreateUserCommand();
            createUserCommand.Item = user;

            UserRepo userRepo = new UserRepo();
            CreateUserCommandHandler createUserCommandHandler = new CreateUserCommandHandler(userValidator, userRepo);

            var addresult = await createUserCommandHandler.Handle(createUserCommand, new CancellationToken());

            GetUserByEmail getUserByEmail = new GetUserByEmail();
            getUserByEmail.Email = user.EMail;

            GetUserByEmailHandler getUserByEmailHandler = new GetUserByEmailHandler(userRepo);
            var getresult = await getUserByEmailHandler.Handle(getUserByEmail, new CancellationToken());
            //Assert.AreEqual(getresult.EMail, user.EMail);
        }
    }
    class UserRepo : IUserRepository
    {
        private List<U.User> users = new List<U.User>();

        public Task<U.User> CreateAsync(U.User model)
        {
            return Task.Run(() => {
                this.users.Add(model);
                return model; 
            });
        }

        public Task<U.User> GetUserByEMailAsync(string email)
        {
            return Task.Run(()=>{
                return this.users.FirstOrDefault(p=>p.EMail==email);
            });
        }

        public Task<U.User> GetUserByUserNameAsync(string username)
        {
            throw new System.NotImplementedException();
        }

        public Task<U.User> UpdateAsync(U.User model)
        {
            throw new System.NotImplementedException();
        }
    }
}

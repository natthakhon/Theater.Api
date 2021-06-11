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
using CQ = Theater.CQRS.Validator.User;
namespace Theater.CQRS.Test
{
    [TestClass]
    public class UnitTest1
    {
        private UserRepo userRepo = new UserRepo();

        [TestMethod]
        public async Task TestAddValidUser()
        {
            U.User user = new U.User
            {
                Name = "test",
                LastName = "test",
                EMail = "test3@test.com",
                Id = 1,
                Password = "A1@aaaaaaa",
                Phone = "1234567890",
                UserName = "test"
            };

            UserValidator userValidator = new UserValidator(userRepo);


            CreateUserCommand createUserCommand = new CreateUserCommand();
            createUserCommand.Item = user;

            CreateUserCommandHandler createUserCommandHandler = new CreateUserCommandHandler(userValidator, userRepo);

            var addresult = await createUserCommandHandler.Handle(createUserCommand, new CancellationToken());

            GetUserByEmail getUserByEmail = new GetUserByEmail();
            getUserByEmail.Email = user.EMail;
            getUserByEmail.Password = user.Password;

            CQ.GetUserByEmailValidator validator = new CQ.GetUserByEmailValidator();

            GetUserByEmailHandler getUserByEmailHandler = new GetUserByEmailHandler(validator, userRepo);
            var getresult = await getUserByEmailHandler.Handle(getUserByEmail, new CancellationToken());
            Assert.AreEqual(getresult.EMail, user.EMail);
        }


        [TestMethod]
        [ExpectedException(typeof(ArgumentException),
                "User is already existed")]
        public async Task TestAddDuplicatedUser()
        {
            U.User user1 = new U.User
            {
                Name = "test",
                LastName = "test",
                EMail = "test1@test.com",
                Id = 1,
                Password = "A1@aaaaaaa",
                Phone = "1234567890",
                UserName = "test1"
            };

            U.User user2 = new U.User
            {
                Name = "test",
                LastName = "test",
                EMail = "test2@test.com",
                Id = 2,
                Password = "A1@aaaaaaa",
                Phone = "1234567890",
                UserName = "test1"  // duplicated user
            };

            UserValidator userValidator = new UserValidator(userRepo);

            CreateUserCommand createUserCommand = new CreateUserCommand();
            createUserCommand.Item = user1;

            CreateUserCommandHandler createUserCommandHandler = new CreateUserCommandHandler(userValidator, userRepo);

            var addresult1 = await createUserCommandHandler.Handle(createUserCommand, new CancellationToken());

            UserValidator userValidator2 = new UserValidator(userRepo);


            CreateUserCommand createUserCommand2 = new CreateUserCommand();
            createUserCommand2.Item = user2;

            CreateUserCommandHandler createUserCommandHandler2 = new CreateUserCommandHandler(userValidator2, userRepo);

            var addresult2 = await createUserCommandHandler2.Handle(createUserCommand2, new CancellationToken());
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
                Phone = "123456789",// wrong phone
                UserName = "test"
            };

            UserValidator userValidator = new UserValidator(userRepo);


            CreateUserCommand createUserCommand = new CreateUserCommand();
            createUserCommand.Item = user;

            CreateUserCommandHandler createUserCommandHandler = new CreateUserCommandHandler(userValidator, userRepo);

            var addresult = await createUserCommandHandler.Handle(createUserCommand, new CancellationToken());
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException),
                "Email must not be empty")]
        public async Task TestRequestInvalidParam()
        {
            GetUserByEmail getUserByEmail = new GetUserByEmail();
            getUserByEmail.Email = "";

            CQ.GetUserByEmailValidator validator = new CQ.GetUserByEmailValidator();

            GetUserByEmailHandler getUserByEmailHandler = new GetUserByEmailHandler(validator, new UserRepo());
            var getresult = await getUserByEmailHandler.Handle(getUserByEmail, new CancellationToken());
        }
    }
    class UserRepo : IUserRepository
    {
        private static List<U.User> users = new List<U.User>();

        public Task<U.User> CreateAsync(U.User model)
        {
            return Task.Run(() => {
                users.Add(model);
                return model; 
            });
        }

        public Task<U.User> GetUserByEMailAsync(string email,string password)
        {
            return Task.Run(()=>{
                return users.FirstOrDefault(p=>p.EMail==email);
            });
        }

        public Task<U.User> GetUserByUserNameAsync(string username, string password)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> IsEmailExisted(string email)
        {
            return Task.Run(() => {
                return users.FirstOrDefault(p => p.EMail == email) != null;
            });
        }

        public Task<bool> IsUserExisted(string user)
        {
            return Task.Run(() => {
                return users.FirstOrDefault(p => p.UserName == user) != null;
            });
        }

        public Task<U.User> UpdateAsync(U.User modify)
        {
            throw new System.NotImplementedException();
        }
    }
}

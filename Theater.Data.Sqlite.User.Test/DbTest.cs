using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Theater.Data.Sqlite.User.Db;
using System.Linq;
using Theater.Security;
using DOM = Theater.Domain.User;
using Theater.Data.Sqlite.User.Mapper;
using Theater.Data.Sqlite.User.Repository;
using System.Threading.Tasks;

namespace Theater.Data.Sqlite.User.Test
{
    [TestClass]
    public class DbTest
    {
        [TestMethod]
        public void TestAdd()
        {
            using (var db = new UserContext())
            {
                var password = new Password("A1@aaaaaaa", 64);
                User user = new User
                {
                    Name = "test",
                    LastName = "test",
                    Email = "test@test.com",
                    Password = password.Hash,
                    Salt =password.Salt,
                    Phone = "1234567890",
                    UserName = "test",
                    CreateDate = DateTime.Now
                };

                db.Add(user);
                db.SaveChanges();

                var getUser = db.Users.FirstOrDefault(p => p.UserName == user.UserName);
                Assert.IsNotNull(getUser);
            }
        }

        [TestMethod]
        public void TestMapDomToData()
        {
            DOM.User user = new DOM.User
            {
                Name = "test",
                LastName = "test",
                EMail = "test@test.com",
                Password = "A1@aaaaaaa",
                Phone = "1234567890",
                UserName = "test"
            };

            UserMapper mapper = new UserMapper(user);
            Assert.AreNotEqual(mapper.Destination.Password, null);
            Assert.AreNotEqual(mapper.Destination.Salt, null);
            Assert.AreNotEqual(mapper.Destination.Password, user.Password);
            Assert.AreEqual(mapper.Destination.Name, user.Name);
            Assert.AreEqual(mapper.Destination.LastName, user.LastName);
            Assert.AreEqual(mapper.Destination.Email, user.EMail);
            Assert.AreEqual(mapper.Destination.Phone, user.Phone);
            Assert.AreEqual(mapper.Destination.UserName, user.UserName);
        }

        [TestMethod]
        public void TestMapDataToDom()
        {
            User user = new User
            {
                Name = "test",
                LastName = "test",
                Email = "test@test.com",
                Password = "A1@aaaaaaa",
                Phone = "1234567890",
                UserName = "test",
                Salt = "Salt",
                CreateDate = DateTime.Now,
                UserID = 1
            };
            UserDataMapper mapper = new UserDataMapper(user);
            Assert.AreEqual(user.UserID, mapper.Destination.Id);
            Assert.AreEqual(user.UserName, mapper.Destination.UserName);
            Assert.AreEqual(user.Email, mapper.Destination.EMail);
            Assert.AreEqual(user.LastName, mapper.Destination.LastName);
            Assert.AreEqual(user.Name, mapper.Destination.Name);
            Assert.AreEqual(user.Phone, mapper.Destination.Phone);
            Assert.AreEqual(mapper.Destination.Password, string.Empty);
        }

        [TestMethod]
        public async Task TestRepositoryAddUser()
        {
            UserRepository userRepository = new UserRepository(new UserContext());
            DOM.User user = new DOM.User
            {
                Name = "test",
                LastName = "test",
                EMail = "test@test.com",
                Password = "A1@aaaaaaa",
                Phone = "1234567890",
                UserName = "test"
            };
            await userRepository.CreateAsync(user);
            var getRightUser = await userRepository.GetUserByUserNameAsync(user.UserName, user.Password);

            Assert.AreEqual(getRightUser.UserName, user.UserName);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException),
                "Not found")]
        public async Task TestRepositoryAddUserGetWorongPassword()
        {
            UserRepository userRepository = new UserRepository(new UserContext());
            DOM.User user = new DOM.User
            {
                Name = "test",
                LastName = "test",
                EMail = "test@test.com",
                Password = "A1@aaaaaaa",
                Phone = "1234567890",
                UserName = "test"
            };
            var addedUseru = await userRepository.CreateAsync(user);
            var getWrongUser = await userRepository.GetUserByUserNameAsync(user.UserName, "12345");
        }
    }
}

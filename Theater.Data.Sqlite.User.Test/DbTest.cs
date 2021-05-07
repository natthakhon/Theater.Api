using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Theater.Data.Sqlite.User.Db;
using System.Linq;
using Theater.Security;
using DOM = Theater.Domain.User;
using Theater.Data.Sqlite.User.Mapper;

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
        public void TestMapper()
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
            Assert.AreNotEqual(mapper.Data.Password, user.Password);
        }
    }
}

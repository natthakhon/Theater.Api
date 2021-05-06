using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Theater.Data.Sqlite.User.Db;
using System.Linq;

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
                User user = new User
                {
                    Name = "test",
                    LastName = "test",
                    Email = "test@test.com",
                    Password = "A1@aaaaaaa",
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
    }
}

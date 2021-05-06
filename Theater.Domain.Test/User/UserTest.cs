using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
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
            var result = new V.User.UserValidator().Validate(user);
            Assert.IsTrue(result.IsValid);
        }
    }
}

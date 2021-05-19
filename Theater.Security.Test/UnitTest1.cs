using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Theater.Security.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Password password = new Password("password", 64);
            Assert.IsFalse(password.IsValid);

            Password enterrightPassword = new Password("password", password.Salt, password.Hash);
            Assert.IsTrue(enterrightPassword.IsValid);

            Password enterwrongPassword = new Password("password123", password.Salt, password.Hash);
            Assert.IsFalse(enterwrongPassword.IsValid);
        }
    }
}

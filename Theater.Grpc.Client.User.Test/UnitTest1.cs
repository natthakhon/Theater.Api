using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;
using Theater.Grpc.Server.User;

namespace Theater.Grpc.Client.User.Test
{
    [TestClass]
    public class UnitTest1
    {
        private string url = "https://localhost:5001";

        [TestMethod]
        public async Task TestUserClient()
        {
            UserClient userClient = new UserClient(this.url);
            var user = await userClient.GetUserByUserNameAsync("nattlao","Natthakhon@1800");
            Assert.IsNotNull(user);
        }        

    }
}

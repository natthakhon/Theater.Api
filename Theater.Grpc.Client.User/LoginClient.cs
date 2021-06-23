using Grpc.Net.Client;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Theater.Grpc.Client.Login;
using Theater.Repository.User;

namespace Theater.Grpc.Client.User
{
    public class LoginClient : ILoginRepository
    {
        private string url;

        public LoginClient(IClientConnection clientConnection)
        {
            this.url = clientConnection.url;
        }
        public Task<Domain.User.Login> CreateAsync(Domain.User.Login model)
        {
            throw new NotImplementedException();
        }

        public async Task<Domain.User.Login> GetLoginById(string loginid)
        {
            using (var channel = GrpcChannel.ForAddress(this.url))
            {
                var client = new Login.Login.LoginClient(channel);
                var reply = await client.GetLoginByIdAsync(new GetLoginByIdRequest
                {
                    Id = loginid
                });
                return new LoginMapper(reply).Destination;
            }
        }

        public Task<Domain.User.Login> UpdateAsync(Domain.User.Login modify)
        {
            throw new NotImplementedException();
        }
    }
}

using Grpc.Net.Client;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Theater.Repository.User;
using dom = Theater.Domain.User;

namespace Theater.Grpc.Client.User
{
    public class UserClient
    {
        private string url;

        public UserClient(string url)
        {
            this.url = url;
        }

        public async Task<dom.User> GetUserByUserNameAsync(string username,string password)
        {
            using (var channel = GrpcChannel.ForAddress(this.url))
            {
                try
                {
                    var client = new User.UserClient(channel);
                    var request = new GetUserByUserNameRequest
                    {
                        Username = username,
                        Password = password
                    };
                    var reply = await client.GetUserByUserNameAsync(request);
                    return new UserMapper(reply).Destination;
                }
                catch(Exception e) 
                {
                    throw e;
                }
            }
        }

        public async Task<List<dom.User>> GetAllUsersAsync()
        {
            List<dom.User> users = new List<dom.User>();
            using (var channel = GrpcChannel.ForAddress(this.url))
            {
                var client = new User.UserClient(channel);
                var reply = client.GetAllUsers(new GetAllUsersRequest{});
                while (await reply.ResponseStream.MoveNext(new System.Threading.CancellationToken()))
                {
                    var current = reply.ResponseStream.Current;
                    users.Add(new UserMapper(current).Destination);
                }
                return users;
            }
        }
    }
}

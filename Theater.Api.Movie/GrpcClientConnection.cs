using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Theater.Grpc.Client.User;

namespace Theater.Api.Movie
{
    public class GrpcClientConnection : IClientConnection
    {
        private string clienturl = string.Empty;
        public GrpcClientConnection() 
        {
            this.clienturl = Environment.GetEnvironmentVariable("GrpcClientUrl");
        }
        public string url { get { return this.clienturl; }  }
    }
}

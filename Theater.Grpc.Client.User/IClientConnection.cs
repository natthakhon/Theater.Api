using System;
using System.Collections.Generic;
using System.Text;

namespace Theater.Grpc.Client.User
{
    public interface IClientConnection
    {
        string url { get; }
    }
}

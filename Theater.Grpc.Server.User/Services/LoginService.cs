using Grpc.Core;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Theater.Grpc.Server.Login;
using Theater.Grpc.Server.User.Mapper.Login;
using Theater.Repository.User;

namespace Theater.Grpc.Server.User.Services
{
    public class LoginService : Login.Login.LoginBase
    {
        private readonly ILogger<LoginService> logger;
        private ILoginRepository loginRepository;

        public LoginService(ILogger<LoginService> logger, ILoginRepository loginRepository)
        {
            this.logger = logger;
            this.loginRepository = loginRepository;
        }

        public override async Task<LoginReply> GetLoginById(GetLoginByIdRequest request, ServerCallContext context)
        {
            var login = await this.loginRepository.GetLoginById(request.Id);

            return new LoginToGLoginMapper(login).Destination;
        }
    }
}

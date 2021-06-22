﻿using Grpc.Core;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Theater.Grpc.Server.User.Mapper.User;
using Theater.Repository.User;

namespace Theater.Grpc.Server.User.Services
{
    public class UserService : User.UserBase
    {
        private readonly ILogger<UserService> logger;
        private IUserRepository userRepository;
        public UserService(ILogger<UserService> logger, IUserRepository userRepository)
        {
            this.logger = logger;
            this.userRepository = userRepository;
        }

        public override async Task<UserReply> GetUserByUserName(GetUserByUserNameRequest request, ServerCallContext context)
        {
            var user = await this.userRepository.GetUserByUserNameAsync(request.Username, request.Password);
            return new UserToGUserMapper(user).Destination;
        }

        public override async Task GetAllUsers(GetAllUsersRequest request, IServerStreamWriter<UserReply> responseStream, ServerCallContext context)
        {
            var users = await this.userRepository.GetAll();

            foreach(var user in users)
            {
                await responseStream.WriteAsync(new UserToGUserMapper(user).Destination);
            }
        }
    }
}

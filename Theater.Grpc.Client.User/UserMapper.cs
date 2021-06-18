using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using Theater.Mapper;
using dom = Theater.Domain.User;

namespace Theater.Grpc.Client.User
{
    public class UserMapper : Theater.Mapper.BaseMapper<UserReply, dom.User>
    {
        public UserMapper(UserReply user) : base(user) { }

        protected override void Reconfig(IMapperConfigurationExpression mapperConfigurationExpression)
        {
            mapperConfigurationExpression.CreateMap<UserReply, dom.User>();
        }
    }
}

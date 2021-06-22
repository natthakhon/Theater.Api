using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using dom = Theater.Domain.User;

namespace Theater.Grpc.Client.User
{
    public class LoginMapper : Theater.Mapper.BaseMapper<Login.LoginReply, dom.Login>
    {
        public LoginMapper(Login.LoginReply loginReply) : base(loginReply) { }

        protected override void Reconfig(IMapperConfigurationExpression mapperConfigurationExpression)
        {
            mapperConfigurationExpression.CreateMap<Login.LoginReply, dom.Login>();
            mapperConfigurationExpression.CreateMap<UserReply, dom.User>();
        }
    }
}

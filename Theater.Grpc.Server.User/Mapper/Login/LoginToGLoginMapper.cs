using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Theater.Grpc.Server.Login;
using dom = Theater.Domain;

namespace Theater.Grpc.Server.User.Mapper.Login
{
    public class LoginToGLoginMapper : Theater.Mapper.BaseMapper<dom.User.Login, LoginReply>
    {
        public LoginToGLoginMapper(dom.User.Login login) : base(login) { }

        protected override void Reconfig(IMapperConfigurationExpression mapperConfigurationExpression)
        {
            mapperConfigurationExpression.CreateMap<dom.User.Login, LoginReply>();
            mapperConfigurationExpression.CreateMap<dom.User.User, UserReply>();
        }
    }
}

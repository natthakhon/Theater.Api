using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dom = Theater.Domain;

namespace Theater.Grpc.Server.User.Mapper.User
{
    public class UserToGUserMapper : Theater.Mapper.BaseMapper<dom.User.User, UserReply>
    {
        public UserToGUserMapper(dom.User.User user) : base(user) { }

        protected override void Reconfig(IMapperConfigurationExpression mapperConfigurationExpression)
        {
            mapperConfigurationExpression.CreateMap<dom.User.User, UserReply>();
        }
    }
}

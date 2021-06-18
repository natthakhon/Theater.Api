using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using Theater.Mapper;
using dom = Theater.Domain.User;

namespace Theater.Data.Sqlite.User.Mapper
{
    public class LoginDomtoDataMapper : BaseMapper<dom.Login, Login>
    {
        public LoginDomtoDataMapper(dom.Login login) : base(login) { }

        protected override void Reconfig(IMapperConfigurationExpression mapperConfigurationExpression)
        {
            mapperConfigurationExpression.CreateMap<dom.Login, Login>();
            mapperConfigurationExpression.CreateMap<dom.User, User>();
        }
    }
}

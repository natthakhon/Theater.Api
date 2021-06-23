using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using Theater.Mapper;
using dom = Theater.Domain.User;

namespace Theater.Data.Sqlite.User.Mapper
{
    public class LoginDatatoDomMapper : BaseMapper<Login, dom.Login>
    {
        public LoginDatatoDomMapper(Login login) : base(login) { }

        protected override void Reconfig(IMapperConfigurationExpression mapperConfigurationExpression)
        {
            mapperConfigurationExpression.CreateMap<Login, dom.Login>();
            mapperConfigurationExpression.CreateMap<User, dom.User>();
        }
    }
}

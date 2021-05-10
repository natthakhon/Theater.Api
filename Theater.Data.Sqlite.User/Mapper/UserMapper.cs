using System;
using System.Collections.Generic;
using System.Text;
using DOM = Theater.Domain.User;
using Theater.Mapper;
using Theater.Security;
using AutoMapper;

namespace Theater.Data.Sqlite.User.Mapper
{
    public class UserMapper : BaseMapper<DOM.User,User>
    {
        Password password = null;

        public UserMapper(DOM.User user) : base(user) { }

        protected override void Reconfig(IMapperConfigurationExpression mapperConfigurationExpression)
        {
            this.password = new Password(this.Source.Password, 64);
            mapperConfigurationExpression.CreateMap<DOM.User, User>()
                .ForMember(dest => dest.Password, act => act.MapFrom(source => this.password.Hash))
                .ForMember(dest => dest.Salt, act => act.MapFrom(source => this.password.Salt));
        }
    }
}

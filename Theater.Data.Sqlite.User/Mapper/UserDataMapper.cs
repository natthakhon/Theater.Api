using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using Theater.Mapper;
using DOM = Theater.Domain.User;

namespace Theater.Data.Sqlite.User.Mapper
{
    public class UserDataMapper : BaseMapper<User, DOM.User>
    {
        public UserDataMapper(User user) : base(user) { }
        protected override void Reconfig(IMapperConfigurationExpression mapperConfigurationExpression)
        {
            mapperConfigurationExpression.CreateMap<User, DOM.User>()
                .ForMember(dest => dest.Password, act => act.MapFrom(source => string.Empty))
                .ForMember(dest => dest.Id, act => act.MapFrom(source => source.UserID));
        }
    }
}

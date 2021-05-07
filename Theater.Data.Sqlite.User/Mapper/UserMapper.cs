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
        public UserMapper(DOM.User user) : base(user) { }

        protected override void Reconfig(IMappingExpression<DOM.User, User> mappingExpression)
        {
            this.mappingExpression.ForMember(dest => dest.Password,
                map => map.MapFrom(source => new Password(source.Password, 64).Hash));
        }
    }
}

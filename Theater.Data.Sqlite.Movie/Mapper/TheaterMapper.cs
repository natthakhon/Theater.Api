using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using Theater.Mapper;
using DOM = Theater.Domain.Movie;

namespace Theater.Data.Sqlite.Movie.Mapper
{
    public class TheaterMapper : BaseMapper<DOM.Theater, Theater>
    {
        public TheaterMapper(DOM.Theater theater) : base(theater) { }

        protected override void Reconfig(IMapperConfigurationExpression mapperConfigurationExpression)
        {
            mapperConfigurationExpression.CreateMap<DOM.Theater, Theater>();
        }
    }
}

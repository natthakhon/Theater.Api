using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using Theater.Mapper;
using DOM = Theater.Domain.Movie;

namespace Theater.Data.Sqlite.Movie.Mapper
{
    public class MovieMapper : BaseMapper<DOM.Movie, Movie>
    {
        public MovieMapper(DOM.Movie movie) : base(movie) { }

        protected override void Reconfig(IMapperConfigurationExpression mapperConfigurationExpression)
        {
            mapperConfigurationExpression.CreateMap<DOM.Movie, Movie>()
                .ForMember(dest => dest.Name, act => act.MapFrom(source => source.MovieName))
                .ForMember(dest => dest.CreateDate, act => act.MapFrom(source => DateTime.Now));
        }
    }
}

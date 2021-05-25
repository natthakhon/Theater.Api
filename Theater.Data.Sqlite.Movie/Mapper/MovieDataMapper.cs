using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using Theater.Mapper;
using DOM = Theater.Domain.Movie;

namespace Theater.Data.Sqlite.Movie.Mapper
{
    public class MovieDataMapper : BaseMapper<Movie, DOM.Movie>
    {
        public MovieDataMapper(Movie movie) : base(movie) { }

        protected override void Reconfig(IMapperConfigurationExpression mapperConfigurationExpression)
        {
            mapperConfigurationExpression.CreateMap<Movie, DOM.Movie>()
                .ForMember(dest => dest.MovieName, act => act.MapFrom(source => source.Name));
        }
    }
}

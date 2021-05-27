using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Theater.CQRS.Movie.Command;
using Theater.Data.Sqlite.Movie.Repository;
using Theater.Domain.Validator.Movie;
using Theater.Repository.Movie;
using DOM = Theater.Domain.Movie;

namespace Theater.Api.Movie
{
    public static class ServiceExtensions
    {
        public static void Resolve(this IServiceCollection services)
        {
            resolveRepository(services);
            resolveCreateMovie(services);
            resolveCreateTheater(services);
        }

        private static void resolveRepository(IServiceCollection services)
        {
            services.AddScoped<IMovieRepository, MovieRepository>();
            services.AddScoped<IMovieChecker, MovieRepository>();
            services.AddScoped<ITheaterRepository, MovieRepository>();
            services.AddScoped<ITheaterChecker, MovieRepository>();
        }

        private static void resolveCreateMovie(IServiceCollection services)
        {
            services.AddScoped<IValidator<DOM.Movie>, MovieValidator>();
            services.AddScoped<IRequestHandler<CreateMovieCommand, DOM.Movie>, CreateMovieCommandHandler>();
        }

        private static void resolveCreateTheater(IServiceCollection services)
        {
            services.AddScoped<IValidator<DOM.Theater>, TheaterValidator>();
            services.AddScoped<IRequestHandler<CreateTheaterCommand, DOM.Theater>, CreateTheaterCommandHandler>();
        }
    }
}

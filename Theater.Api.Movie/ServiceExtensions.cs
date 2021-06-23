using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Theater.CQRS.Movie.Command;
using Theater.CQRS.Movie.Query;
using Theater.Data.Sqlite.Movie.Repository;
using Theater.Domain.Validator.Movie;
using Theater.Grpc.Client.User;
using Theater.Repository;
using Theater.Repository.Movie;
using Theater.Repository.User;
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
            resolveGetAllMovies(services);
        }

        private static void resolveRepository(IServiceCollection services)
        {
            services.AddScoped<IMovieRepository, MovieRepository>();
            services.AddScoped<IMovieChecker, MovieRepository>();
            services.AddScoped<ITheaterRepository, MovieRepository>();
            services.AddScoped<IClientConnection, GrpcClientConnection>();
            services.AddScoped<ILoginRepository, Theater.Grpc.Client.User.LoginClient>();
            services.AddScoped<ITheaterChecker, MovieRepository>();
            services.AddScoped<IGetData<List<DOM.Movie>>, MovieRepository>();
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

        private static void resolveGetAllMovies(IServiceCollection services)
        {
            services.AddScoped<IRequestHandler<GetAllMovies, List<DOM.Movie>>, GetAllMoviesHandler>();
        }
    }
}

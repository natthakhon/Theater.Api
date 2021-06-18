using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Theater.CQRS.User.Command;
using Theater.CQRS.User.Query;
using Theater.CQRS.Validator.User;
using Theater.Data.Sqlite.User.Repository;
using Theater.Domain.Validator.User;
using Theater.Repository.User;
using DOM = Theater.Domain.User;

namespace Theater.Api.User
{
    public static class ServiceExtensions
    {
        public static void Resolve(this IServiceCollection services)
        {
            resolveRepository(services);
            resolveGetUserByUserName(services);
            resolveGetUserByEmail(services);
            resolveCreateUser(services);
            resolveGetLoginById(services);
            resolveCreateLogin(services);
        }

        private static void resolveRepository(IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserChecker, UserRepository>();
            services.AddScoped<ILoginRepository, LoginRepository>();
        }

        private static void resolveGetUserByUserName(IServiceCollection services)
        {
            services.AddScoped<IValidator<GetUserByUserName>, GetUserByUserNameValidator>();
            services.AddScoped<IRequestHandler<GetUserByUserName, DOM.User>, GetUserByUserNameHandler>();
        }

        private static void resolveGetUserByEmail(IServiceCollection services)
        {
            services.AddScoped<IValidator<GetUserByEmail>, GetUserByEmailValidator>();
            services.AddScoped<IRequestHandler<GetUserByEmail, DOM.User>, GetUserByEmailHandler>();
        }

        private static void resolveCreateUser(IServiceCollection services)
        {
            services.AddScoped<IValidator<DOM.User>, UserValidator>();
            services.AddScoped<IRequestHandler<CreateUserCommand, DOM.User>, CreateUserCommandHandler>();
        }

        private static void resolveGetLoginById(IServiceCollection services)
        {
            services.AddScoped<IValidator<GetLoginById>, GetLoginByIdValidator>();
            services.AddScoped<IRequestHandler<GetLoginById, DOM.Login>, GetLoginByIdHandler>();
        }

        private static void resolveCreateLogin(IServiceCollection services)
        {
            services.AddScoped<IValidator<DOM.Login>, LoginValidator>();
            services.AddScoped<IRequestHandler<CreateLoginCommand, DOM.Login>, CreateLoginCommandHandler>();
        }
    }
}

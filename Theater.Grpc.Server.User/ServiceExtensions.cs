using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Theater.Data.Sqlite.User.Repository;
using Theater.Repository.User;

namespace Theater.Grpc.Server.User
{
    public static class ServiceExtensions
    {
        public static void Resolve(this IServiceCollection services)
        {
            resolveRepository(services);
        }

        private static void resolveRepository(IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ILoginRepository, LoginRepository>();
        }
    }
}

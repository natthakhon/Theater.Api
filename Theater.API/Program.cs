using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using NLog;
using NLog.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Theater.API.NLog;

namespace Theater.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            ConfigNlog configNlog = new ConfigNlog(Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT"));
            LogManager.Configuration = configNlog.GetLogConfig();
            var logger = LogManager.GetCurrentClassLogger();

            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}

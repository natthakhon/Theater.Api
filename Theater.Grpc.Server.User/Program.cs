using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using NLog;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Theater.NLogger;
using Microsoft.Extensions.Logging;
using NLog.Web;

namespace Theater.Grpc.Server.User
{
    public class Program
    {
        public static void Main(string[] args)
        {
            ConfigNlog configNlog = new ConfigNlog(Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT"));
            LogManager.Configuration = configNlog.GetLogConfig();
            var logger = LogManager.GetCurrentClassLogger();
            try
            {
                logger.Debug("Application Starting Up");
                CreateHostBuilder(args).Build().Run();
            }
            catch (Exception exception)
            {
                logger.Error(exception, "Stopped program because of exception");
                throw;
            }
            finally
            {
                NLog.LogManager.Shutdown();
            }
        }

        // Additional configuration is required to successfully run gRPC on macOS.
        // For instructions on how to configure Kestrel and gRPC clients on macOS, visit https://go.microsoft.com/fwlink/?linkid=2099682
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                })
                .ConfigureLogging(logging =>
                {
                    logging.ClearProviders();
                    logging.SetMinimumLevel(Microsoft.Extensions.Logging.LogLevel.Trace);
                })
                .UseNLog();

    }
}

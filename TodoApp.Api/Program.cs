using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Serilog;

namespace TodoApp.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                var webHost = CreateHostBuilder(args).Build();
                Log.Information("Starting web host...");
                webHost.Run();
            }
            catch (Exception e)
            {
                Log.Fatal(e, "Host terminated unexpectedly");
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration(((context, builder) =>
                {
                    var env = Environment.GetEnvironmentVariable("ENVIRONMENT");
                    builder
                        .AddJsonFile("appsettings.json")
                        .AddJsonFile($"appsettings.{env}.json");

                }))
                .ConfigureWebHostDefaults(webBuilder => { webBuilder.UseStartup<Startup>(); })
                .UseSerilog((context, configuration) => { configuration.ReadFrom.Configuration(context.Configuration); });
    }
}
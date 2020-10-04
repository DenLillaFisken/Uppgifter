using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;
using Serilog.Events;

namespace UPG1_VG
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //fr�n serilog, skapar loggfil lokalt
            Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Debug()
            .MinimumLevel.Override("Microsoft", LogEventLevel.Warning)
            .Enrich.FromLogContext()
            .WriteTo.File(@"c:\workerservice3\log\LogFile.txt")
            .CreateLogger();

            try
            {
                Log.Information("Starting WorkerService...");
                CreateHostBuilder(args).Build().Run();
                return;
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, $"WorkerService terminated unexpectedly. Error:: {ex.Message}");
                return;
            }
            finally
            {
                Log.CloseAndFlush();
            }

        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                //skapar loggfil
                .UseSerilog()
                //skapar windowsapplikationen
                .UseWindowsService()
                //konfigurerar applikationen
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddHostedService<Worker>();
                });
    }
}
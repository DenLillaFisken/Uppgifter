using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Uppgift1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //skapar ett slumpartat värde mellan -20 och 35.
            Random rnd = new Random();
            int temperature = rnd.Next(-20, 35);  // temperatur mellan -20 till 35 celcius.

            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddHostedService<Worker>();
                });
    }
}

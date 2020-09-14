using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Uppgift1.Models;

namespace Uppgift1
{
    public class Worker : BackgroundService
    {
        //Ilogger är en loggningsfunktion, bara inom klassen, kan inte ändras
        private readonly ILogger<Worker> _logger;
        private int _temperature;
        
        public Worker(ILogger<Worker> logger)
        {
            _logger = logger;
        }

        public override Task StartAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("The service started.");
            return base.StartAsync(cancellationToken);
        }
        public override Task StopAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("The service stopped.");
            return base.StopAsync(cancellationToken);
        }
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            TempData getRandomNumber = new TempData();
            while (!stoppingToken.IsCancellationRequested)
            {
                _temperature = getRandomNumber.GenerateRandomTemp();
                _logger.LogInformation($"The temperature is {_temperature}. {getRandomNumber.TempControl(_temperature)}");
                await Task.Delay(60 * 1000, stoppingToken);
            }
        }
    }
}

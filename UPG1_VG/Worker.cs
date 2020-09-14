using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using UPG1_VG.Models;

namespace UPG1_VG
{
    public class Worker : BackgroundService
    {

        private readonly ILogger<Worker> _logger;
        private readonly string _url = "http://api.openweathermap.org/data/2.5/weather?q=London,uk&APPID=2dc4bdc55e1ef3875e3db242278e1794";

        private HttpClient _client;
        private HttpResponseMessage _result;
        private string _getJson;

        public Worker(ILogger<Worker> logger)
        {
            _logger = logger;
        }

        public override Task StartAsync(CancellationToken cancellationToken)
        {
            _client = new HttpClient();
            _logger.LogInformation("The service has been started.");
            return base.StartAsync(cancellationToken);
        }

        public override Task StopAsync(CancellationToken cancellationToken)
        {
            _client.Dispose();
            _logger.LogInformation("The service has been stopped.");
            return base.StopAsync(cancellationToken);
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            ControlTemperature controltemp = new ControlTemperature();
            while (!stoppingToken.IsCancellationRequested)
            {
                try
                {
                    _result = await _client.GetAsync(_url);
                    _getJson = await _result.Content.ReadAsStringAsync();

                    dynamic data = JObject.Parse(_getJson);
                    var temp = data.main.temp;

                    double kelvin = Convert.ToDouble(temp);
                    double celsius = Math.Round(kelvin - 273.15, 1);

                    _logger.LogInformation($"The temperature is {celsius} Celsius. {controltemp.TempControl(celsius)}");
                }
                catch
                {
                    _logger.LogInformation($"Could not show temperature");
                }


                await Task.Delay(60*1000, stoppingToken);
            }
        }
    }
}
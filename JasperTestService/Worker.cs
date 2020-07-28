using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Jasper;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace JasperTestService
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly ICommandBus _bus;

        public Worker(ILogger<Worker> logger, ICommandBus bus)
        {
            _logger = logger;
            _bus = bus;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
                await _bus.Enqueue(new CreateItemCommand { Name = $"Item at {DateTimeOffset.Now}" });

                await Task.Delay(2000, stoppingToken);
            }
        }
    }
}

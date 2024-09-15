using Microsoft.Extensions.Options;

namespace WorkerServiceSample
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly WorkerConfiguration _configuration;

        public Worker(ILogger<Worker> logger, IOptions<WorkerConfiguration> configuration)
        {
            _logger = logger;
            _configuration = configuration.Value;
        }

        public override Task StartAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation($"{nameof(Worker)}: WorkerServiceSample Start");
            return base.StartAsync(cancellationToken);
        }

        public override Task StopAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation($"Stop {DateTimeOffset.Now}");
            return base.StopAsync(cancellationToken);
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var secondsToWaitFirstTime = HelpersLibrary.CalculateFirstTimeStart(_configuration.WorkerStartTime);
            _logger.LogInformation("Next execution at " + secondsToWaitFirstTime + " seconds");
            // wait till midnight
            await Task.Delay(TimeSpan.FromSeconds(secondsToWaitFirstTime), stoppingToken);

            while (!stoppingToken.IsCancellationRequested)
            {
                // do stuff
                _logger.LogInformation($"Starting process at: " + DateTime.Now.ToString());

                // wait 24 hours
                await Task.Delay(TimeSpan.FromMinutes(1), stoppingToken);
            }
        }
    }
}

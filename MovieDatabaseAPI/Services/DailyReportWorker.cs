using MovieDatabaseAPI.Models;

namespace MovieDatabaseAPI.Worker
{
    public class DailyReportWorker : BackgroundService
    {
        private readonly ILogger<DailyReportWorker> _logger;
        private readonly MovieContext _context;

        public DailyReportWorker(ILogger<DailyReportWorker> logger, MovieContext context)
        {
            _logger = logger;
            _context = context;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation("Generating and publishing daily report...");

                // Your report generation logic here

                await Task.Delay(TimeSpan.FromDays(1), stoppingToken); // Run daily
            }
        }
    }
}

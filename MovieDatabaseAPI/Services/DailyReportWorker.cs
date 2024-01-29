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

                while (!stoppingToken.IsCancellationRequested)
                {
                    // Generate and publish daily report
                    var currentTime = DateTime.Now;
                    var reportMessage = $"Daily report generated at: {currentTime}";

                    // Log the report message
                    _logger.LogInformation(reportMessage);

                    // Simulate some processing time (e.g., writing to a file, sending an email)
                    await Task.Delay(TimeSpan.FromSeconds(10), stoppingToken); // Simulated processing time

                    // Delay until the next day
                    var nextDay = currentTime.AddDays(1).Date;
                    var timeUntilNextDay = nextDay - currentTime;
                    await Task.Delay(timeUntilNextDay, stoppingToken);
                }
            }
        }
    }
}

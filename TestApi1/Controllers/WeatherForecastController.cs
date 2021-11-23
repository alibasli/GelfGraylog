using Microsoft.AspNetCore.Mvc;

namespace TestApi1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            _logger.Log(LogLevel.None, "Log none: TestApi1 WeatherForecast Get method triggered!");
            _logger.LogInformation("LogInformation: TestApi1 WeatherForecast Get method triggered!");
            _logger.LogDebug("LogDebug: TestApi1 WeatherForecast Get method triggered!");
            _logger.LogError("LogError: TestApi1 WeatherForecast Get method triggered!");
            _logger.LogCritical("LogCritical: TestApi1 WeatherForecast Get method triggered!");
            _logger.LogWarning("LogWarning: TestApi1 WeatherForecast Get method triggered!");
            _logger.LogTrace("LogTrace: TestApi1 WeatherForecast Get method triggered!");

            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}
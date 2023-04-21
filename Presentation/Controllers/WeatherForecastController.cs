using Application.Responses;
using ReaProjKnowIT.Core.Domain;
using Microsoft.AspNetCore.Mvc;

namespace ReaProjKnowIT.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<WeatherForecastResponse> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecastResponse
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = WeatherData.WeatherSummaries[Random.Shared.Next(WeatherData.WeatherSummaries.Length)]
            })
            .ToArray();
        }
    }
}
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Invigorating", "Cold", "Refreshing", "Moderate", "Toasty", "Pleasant", "Sizzling", "Roasting", "Blistering"
    };

        [HttpGet]
        public IEnumerable<WeatherForecast> Get([FromQuery] WeatherRequest request)
        {
            var randomRange = new Random();
			var forecasts = new List<WeatherForecast>();
			for (int i = 0; i < request.numberOfDays; i++)
			{
				var celsium = randomRange.Next(request.minValue, request.maxValue);
				var farengeit = 32 + (int)(celsium / 0.555);
				forecasts.Add(new WeatherForecast
                {
					Date = DateTime.Now.AddDays(i),
					tempC = celsium,
					tempF = farengeit,
					Summary = Summaries[randomRange.Next(Summaries.Length)]
				});
			}
			return forecasts;
        }

        [HttpPost]
        public string Post(WeatherForecast forecast)
        {

            return "Горить палає техніка ворожа";
        }
    }
}

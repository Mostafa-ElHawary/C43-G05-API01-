using Microsoft.AspNetCore.Mvc;
using static System.Net.WebRequestMethods;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace IntorductionSessionApis.Controllers
{
    [ApiController]

    //[Route("[controller]")]: This defines the base route for all endpoints in this controller.
    //[controller] is replaced with the name of the controller (without the "Controller" suffix).
    //In this case, the route becomes /weatherforecast.

    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        //ILogger<WeatherForecastController>: This is a dependency injected into the controller via its constructor.
        //It allows logging of information, warnings, errors, etc., for debugging or monitoring purposes.

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }

        // How the API Works
        //Request :
        //A client sends an HTTP GET request to the /weatherforecast endpoint(e.g., GET https://localhost:5001/weatherforecast).
        //The[HttpGet] attribute ensures that this method handles the request.
        //Processing :
        //The Get method generates five random weather forecast entries using the logic described above.
        //Each entry includes:
        //A future date(Date).
        //A random temperature in Celsius(TemperatureC).
        //A random weather summary(Summary).
        // Response :
        //        [
        //  {
        //    "date": "2023-10-05",
        //    "temperatureC": 23,
        //    "summary": "Warm"
        //  },
        //  {
        //    "date": "2023-10-06",
        //    "temperatureC": 30,
        //    "summary": "Hot"
        //  },
        //  ...
        //]
    }
}

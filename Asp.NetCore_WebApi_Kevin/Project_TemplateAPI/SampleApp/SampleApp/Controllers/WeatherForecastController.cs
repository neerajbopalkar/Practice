using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace SampleApp.Controllers
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

        [HttpGet("api/weather")]
        public IActionResult Get()
        {

            return new JsonResult(WeatherDataStore.WeatherList);
        }

        [HttpGet("api/weather/{summary}")]
        public IActionResult Get(string summary)
        {
            var ret = WeatherDataStore.WeatherList.FirstOrDefault(entry => entry.Summary.ToUpper() == summary.ToUpper());
            if (ret == null)
                return NotFound();

            return new JsonResult(ret) ;
        }
    }

    public class WeatherDataStore
    {
        public static WeatherDataStore Current = new WeatherDataStore();

        public static List<WeatherForecast> WeatherList = new List<WeatherForecast>();
        private static readonly string[] Summaries = new[]
     {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };
        static WeatherDataStore()
        {

            var rng = new Random();
            WeatherList = Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            }).ToList();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EShop.webapi.Models;
using EShop.webapi.Services;

namespace EShop.webapi.Repository
{
    public class WeatherForecastRepository: IWeatherForecastService
    {
        private static string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };
        public async Task<WeatherForecast[]> GetWeatherForecastAsync()
        {

            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            }).ToArray();
        }
    }
}
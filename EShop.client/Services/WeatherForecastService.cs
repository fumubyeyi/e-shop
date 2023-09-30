using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using EShop.logic.Models;
using EShop.shared.Pages.WeatherData;

namespace EShop.client.Services
{
    public class WeatherForecastService : IWeatherForecastService
    {
        private readonly HttpClient http;
        public WeatherForecastService(HttpClient http)
        {
            this.http = http;
        }
        public async Task<WeatherForecast[]> GetWeatherForecastAsync()
        {
            return await http.GetFromJsonAsync<WeatherForecast[]>("_content/EShop.shared/sample-data/weather.json");
        }
    }
}
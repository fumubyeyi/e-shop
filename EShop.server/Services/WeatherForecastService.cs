using System;
using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using EShop.shared.Models;
using EShop.shared.Interfaces;

namespace EShop.server.Services
{
    public class WeatherForecastService : IWeatherForecastService
    {        
        private readonly HttpClient http;
       private readonly NavigationManager navManager;
        public WeatherForecastService(HttpClient http)
        {
            this.http = http;
            this.navManager = navManager;
        }
        public async Task<WeatherForecast[]> GetWeatherForecastAsync()
        {
            http.BaseAddress = new Uri(navManager.BaseUri);
            return await http.GetFromJsonAsync("_content/EShop.shared/sample-data/weather.json");
        }
    }
}
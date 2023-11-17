using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EShop.webapi.Models;

namespace EShop.webapi.Services
{
    public interface IWeatherForecastService
    {
        Task<WeatherForecast[]> GetWeatherForecastAsync();
    }
}
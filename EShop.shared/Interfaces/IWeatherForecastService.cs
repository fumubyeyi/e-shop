using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EShop.shared.Models;

namespace EShop.shared.Interfaces
{
    public interface IWeatherForecastService
    {
        Task<WeatherForecast[]> GetWeatherForecastAsync();
    }
}
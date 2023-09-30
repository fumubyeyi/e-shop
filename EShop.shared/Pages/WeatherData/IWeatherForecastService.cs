using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EShop.logic.Models;

namespace EShop.shared.Pages.WeatherData
{
    public interface IWeatherForecastService
    {
        Task<WeatherForecast[]> GetWeatherForecastAsync();
    }
}
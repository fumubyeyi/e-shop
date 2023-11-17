using Microsoft.AspNetCore.Mvc;
using EShop.webapi.Models;
using EShop.webapi.Services;

namespace EShop.webapi.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private readonly IWeatherForecastService _weatherService;
    private readonly ILogger<WeatherForecastController> _logger;

    public WeatherForecastController(ILogger<WeatherForecastController> logger, IWeatherForecastService service)
    {
        _logger = logger;
        _weatherService = service;
    }

    [HttpGet(Name = "GetWeatherForecast")]
    public async Task<WeatherForecast[]> Get()
    {
        return await _weatherService.GetWeatherForecastAsync();
    }
}

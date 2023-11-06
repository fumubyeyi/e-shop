using System.Net.Http.Json;
using EShop.shared.Models;
using EShop.shared.Interfaces;
namespace EShop.maui.Services;

public class WeatherForecastServiceMaui: IWeatherForecastService
{
	private readonly HttpClient http;
	public WeatherForecastServiceMaui(HttpClient http)
	{
		this.http = http;
	}
	public async Task<WeatherForecast[]> GetWeatherForecastAsync()
	{
		return await http.GetFromJsonAsync<WeatherForecast[]>("_content/EShop.shared/sample-data/weather.json");
	}
}


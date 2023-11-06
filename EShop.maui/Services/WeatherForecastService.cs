using System.Net.Http.Json;
using EShop.shared.Models;
using EShop.shared.Interfaces;
namespace EShop.maui.Services;

public class WeatherForecastService: IWeatherForecastService
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


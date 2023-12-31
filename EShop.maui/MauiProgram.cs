﻿using Microsoft.Extensions.Logging;
using EShop.maui.Services;
using EShop.shared.Interfaces;

namespace EShop.maui;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
			});

		builder.Services.AddMauiBlazorWebView();
        builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("http://localhost:5086") });
        builder.Services.AddSingleton<IWeatherForecastService, WeatherForecastServiceMaui>();

#if DEBUG
		builder.Services.AddBlazorWebViewDeveloperTools();
		builder.Logging.AddDebug();
#endif
        return builder.Build();
	}
}

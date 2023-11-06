using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using EShop.client;
using EShop.client.Services;
using EShop.shared.Interfaces;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");
builder.Services.AddHttpClient<IWeatherForecastService, WeatherForecastService>(client =>
{
    client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress);
});

await builder.Build().RunAsync();
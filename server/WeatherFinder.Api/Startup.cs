using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using WeatherFinder.Api.Interfaces;
using WeatherFinder.Api.Services;

[assembly: FunctionsStartup(typeof(WeatherFinder.Api.Startup))]
namespace WeatherFinder.Api
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            builder.Services.AddSingleton<IWeatherService, WeatherService>();
        }
    }
}
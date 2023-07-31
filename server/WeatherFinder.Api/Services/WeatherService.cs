using Newtonsoft.Json;
using System.Net.Http;
using System;
using System.Threading.Tasks;
using WeatherFinder.Api.Interfaces;
using WeatherFinder.Api.Models.Requests;
using WeatherFinder.Api.Models.Responses;
using WeatherFinder.Api.Models;

namespace WeatherFinder.Api.Services
{
    public class WeatherService : IWeatherService
    {
        private readonly string apiKey;

        public WeatherService()
        {
            apiKey = Environment.GetEnvironmentVariable("WEATHER_API_KEY");
        }

        public async Task<Response<WeatherResponse>> Get(WeatherRequest request)
        {
            var result = new Response<WeatherResponse>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(String.Format($"https://api.openweathermap.org/"));

                if (!string.IsNullOrEmpty(request.City))
                {
                    var response = await client.GetAsync(String.Format("data/2.5/weather?q={0}&appid={1}", request.City, apiKey));
                    var weatherData = JsonConvert.DeserializeObject<WeatherData>(await response.Content.ReadAsStringAsync());
                    result.Result = ConvertResponse(weatherData);
                }
                else if (!string.IsNullOrEmpty(request.Zipcode))
                {
                    var response = await client.GetAsync(String.Format("data/2.5/weather?zip={0},us&appid={1}", request.Zipcode, apiKey));
                    var weatherData = JsonConvert.DeserializeObject<WeatherData>(await response.Content.ReadAsStringAsync());
                    result.Result = ConvertResponse(weatherData);
                }
                else if (request.Lat != null && request.Long != null)
                {
                    var response = await client.GetAsync(String.Format("data/2.5/weather?lat={0}&lon={1}&appid={2}", request.Lat, request.Long, apiKey));
                    var weatherData = JsonConvert.DeserializeObject<WeatherData>(await response.Content.ReadAsStringAsync());
                    result.Result = ConvertResponse(weatherData);
                }
                else
                {
                    result.Errors.Add("Bad Request");
                }
            }

            return result;
        }

        private WeatherResponse ConvertResponse(WeatherData response)
        {
            return new WeatherResponse
            {
                Description = response.Weather[0].Main,
                CurrentTemp = response.Main.Temp,
                MaxTemp = response.Main.Temp_Max,
                MinTemp = response.Main.Temp_Min
            };
        }
    }
}

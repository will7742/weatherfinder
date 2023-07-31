using System.Threading.Tasks;
using WeatherFinder.Api.Models.Requests;
using WeatherFinder.Api.Models.Responses;

namespace WeatherFinder.Api.Interfaces
{
    public interface IWeatherService
    {
        Task<Response<WeatherResponse>> Get(WeatherRequest request);
    }
}

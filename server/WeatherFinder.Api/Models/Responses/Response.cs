using System.Collections.Generic;

namespace WeatherFinder.Api.Models.Responses
{
    public class Response<T>
    {
        public List<string> Errors { get; set; } = new List<string>();

        public T Result { get; set; }
    }

}

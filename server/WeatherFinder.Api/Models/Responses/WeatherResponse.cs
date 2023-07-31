namespace WeatherFinder.Api.Models.Responses
{
    public class WeatherResponse
    {
        public string Description { get; set; }
        public double CurrentTemp { get; set; }
        public double MinTemp { get; set; }
        public double MaxTemp { get; set; }
    }
}

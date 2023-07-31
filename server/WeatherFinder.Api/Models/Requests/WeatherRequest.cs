namespace WeatherFinder.Api.Models.Requests
{
    public class WeatherRequest
    {
        public string City { get; set; }
        public string Zipcode { get; set; }
        public double? Lat { get; set; }
        public double? Long { get; set; }
    }
}

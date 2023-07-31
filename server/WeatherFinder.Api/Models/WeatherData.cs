using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherFinder.Api.Models
{
    public class WeatherData
    {
        public List<WeatherDataDescription> Weather { get; set; }
        public WeatherDataMain Main { get; set; }
    }

    public class WeatherDataDescription
    {
        public string Main { get; set; }
        public string Description { get; set; }
    }

    public class WeatherDataMain
    {
        public double Temp { get; set; }
        public double Temp_Min { get; set; }
        public double Temp_Max { get; set; }
    }
}

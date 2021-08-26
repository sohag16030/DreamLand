using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DBFirst.DTO
{
    public class WeatherInfo
    {
        public decimal Temp { get; set; }
        public decimal Feels_like { get; set; }
        public decimal Temp_min { get; set; }
        public decimal Temp_max { get; set; }
        public decimal Pressure { get; set; }
        public decimal Humidity { get; set; }
        public decimal Sea_level { get; set; }
        public decimal Grnd_level { get; set; }
    }
}

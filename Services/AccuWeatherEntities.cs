using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CityWeatherApp.Services
{

    public class CityLocation
    {
        public string Key { get; set; }
        public string LocalizedName { get; set; }
    }


    public class AccuCurrentWeather
    {
        public string WeatherText { get; set; }
        public Temperature Temperature { get; set; }
    }

    public class Temperature
    {
        public Metric Metric { get; set; }
    }

    public class Metric
    {
        public double Value { get; set; }
    }




}

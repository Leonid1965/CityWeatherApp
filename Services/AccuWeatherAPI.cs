using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CityWeatherApp.Models;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace CityWeatherApp.Services
{
    public class AccuWeatherAPI : IAccuWeatherAPI
    {
        IConfiguration config;
        public AccuWeatherAPI(IConfiguration config)
        {
            this.config = config;
 
        }

        public async Task<CurrentWeather> GetCurrentWeather(string cityKey)
        {
            //http://dataservice.accuweather.com/currentconditions/v1/215849?apikey=VhcrvEMHNqg0hJlRwCAUeqzNbqaySGjR&language=en-us&details=false

            string accuWeatherAPIKey = config["AccuWeather:APIKey"];
            string url = config["AccuWeather:CurrentWeather"]; 
            url = string.Format(url, cityKey, accuWeatherAPIKey);

            string currentWeatherStr = await HttpDataReceiver.GetWebData(url);
            AccuCurrentWeather[] accuCurrentWeather = JsonConvert.DeserializeObject<AccuCurrentWeather[]>(currentWeatherStr);
            CurrentWeather currentWeather = new CurrentWeather{ CityKey = cityKey, 
                                                                TemperatureCV = accuCurrentWeather[0].Temperature.Metric.Value, 
                                                                WeatherText = accuCurrentWeather[0].WeatherText
                                                                };

            return currentWeather;
        }

        public async Task<CityLocation[]> LocationAutocomplete(string city)
        {
            //http://dataservice.accuweather.com/locations/v1/cities/autocomplete?apikey=VhcrvEMHNqg0hJlRwCAUeqzNbqaySGjR&q=tel&language=en-us

            string accuWeatherAPIKey = config["AccuWeather:APIKey"];
            string url = config["AccuWeather:LocationAutocomplete"]; 
            url = string.Format(url, accuWeatherAPIKey, city);

            string citiesStr = await HttpDataReceiver.GetWebData(url);
            CityLocation[] cityLocations  = JsonConvert.DeserializeObject<CityLocation[]>(citiesStr);

            return cityLocations;
        }
    }
}

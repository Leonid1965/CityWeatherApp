using CityWeatherApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CityWeatherApp.Services
{
    public interface IAccuWeatherAPI
    {
        Task<CityLocation[]> LocationAutocomplete(string city);
        Task<CurrentWeather> GetCurrentWeather(string cityKey);
    }
}
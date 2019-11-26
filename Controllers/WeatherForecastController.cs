using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using CityWeatherApp.Data;
using CityWeatherApp.Models;
using CityWeatherApp.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace CityWeatherApp.Controllers
{
    public class WeatherForecastController : Controller
    {

        private readonly WeatherDb weatherDb;
        private readonly IAccuWeatherAPI accuWeatherAPI;

        public WeatherForecastController(WeatherDb weatherDb, IAccuWeatherAPI accuWeatherAPI)
        {
            this.weatherDb = weatherDb;
            this.accuWeatherAPI = accuWeatherAPI;
        }


        //http://localhost:49186/weatherforecast/Search?city=215854
        [HttpGet]
        public async Task<ActionResult<CityLocation[]>> Search(string city)
        {
            CityLocation[] cityLocations = await accuWeatherAPI.LocationAutocomplete(city);
            return cityLocations;
        }

        //http://localhost:49186/weatherforecast/GetCurrentWeather?cityKey=215854
        [HttpGet]
        public async Task<CurrentWeather> GetCurrentWeather(string cityKey)
        {


            CurrentWeather currentWeather = await weatherDb.CurrentWeather.FirstOrDefaultAsync(m => m.CityKey == cityKey);
            if (currentWeather == null)
            {
                currentWeather = await accuWeatherAPI.GetCurrentWeather(cityKey);

                weatherDb.CurrentWeather.Add(currentWeather);
                await weatherDb.SaveChangesAsync();

            }

            return currentWeather;
        }


        [HttpPost]
        public async Task<string> AddToFavorites(string cityKey, string localizedName)
        {
            string message = "";
            try
            {
                var cityFavorite = await weatherDb.CityFavorite.FindAsync(cityKey);
                if (cityFavorite == null)
                {
                    cityFavorite = new CityFavorite { CityKey = cityKey, LocalizedName = localizedName };

                    weatherDb.CityFavorite.Add(cityFavorite);
                    await weatherDb.SaveChangesAsync();
                }
            }
            catch (Exception e)
            {
                message =e.Message;
            }
            return message;
        }


         [HttpDelete]
        public async Task<string> DeleteFavorite(string cityKey)
        {
            string message = "";
            try
            {
                var cityFavorite = await weatherDb.CityFavorite.FindAsync(cityKey);
                if (cityFavorite != null)
                {
                    weatherDb.CityFavorite.Remove(cityFavorite);
                    await weatherDb.SaveChangesAsync();
                }
            }
            catch (Exception e)
            {
                message = e.Message;
            }
            return message;
        }



        //http://localhost:49186/weatherforecast/GetCityFavorites
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CityFavorite>>> GetCityFavorites()
        {
            try
            {
                return (await weatherDb.CityFavorite.ToArrayAsync());
            }
            catch(Exception e)
            {
                throw e;
            }
        }
           
       

    }
}

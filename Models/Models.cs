using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CityWeatherApp.Models
{
    public class CurrentWeather
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [StringLength(50)]
        [Key]
        public string CityKey { get; set; }      
        public double TemperatureCV { get; set; }
        [StringLength(200)]
        public string WeatherText { get; set; }
    }

    public class CityFavorite
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [StringLength(50)]
        [Key]
        public string CityKey { get; set; }
        [StringLength(100)]
        public string LocalizedName { get; set; }
    }


 
}

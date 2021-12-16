using System;
using System.ComponentModel.DataAnnotations;

namespace Example.DataRepository
{
    public class WeatherForecast
    {
        [Key] 
        public int Id { get; set; }

        [Required] 
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        [Required] 
        public int TemperatureC { get; set; }

        public int TemperatureF => 32 + (int) (TemperatureC / 0.5556);

        [Required] 
        public string Summary { get; set; }
    }
}
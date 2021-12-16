using System.Collections.Generic;
using System.Linq;
using Example.BusinessLogic;
using Example.DataAccess;
using Example.DataRepository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Example.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly WeatherForecastService _repository;
        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(WeatherForecastService repository,
            ILogger<WeatherForecastController> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            return _repository.GetAllWeathers();
        }
    }
}
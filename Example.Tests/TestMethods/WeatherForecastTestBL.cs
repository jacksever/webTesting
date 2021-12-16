using System;
using System.Collections.Generic;
using System.Linq;
using Example.BusinessLogic;
using Example.DataAccess;
using Example.DataRepository;
using Moq;
using NUnit.Framework;

namespace Example.Tests.TestMethods;

public class WeatherForecastTestBL
{
    private Mock<IEntityRepository<WeatherForecast>> weatherForecastRepository;
    private List<WeatherForecast> weatherForecasts;

    [SetUp]
    public void Setup()
    {
        weatherForecastRepository = new Mock<IEntityRepository<WeatherForecast>>();
        weatherForecasts = new List<WeatherForecast>
        {
            new()
            {
                Id = 1,
                Date = DateTime.Parse("2020-2-12"),
                TemperatureC = 18,
                Summary = "Chilly"
            },
            new()
            {
                Id = 2,
                Date = DateTime.Parse("2020-2-12"),
                TemperatureC = 34,
                Summary = "Warm"
            },
            new()
            {
                Id = 3,
                Date = DateTime.Parse("2020-2-12"),
                TemperatureC = -3,
                Summary = "Freezing"
            },
            new()
            {
                Id = 4,
                Date = DateTime.Parse("2020-2-12"),
                TemperatureC = 17,
                Summary = "Mild"
            }
        };
    }

    [Test]
    public void TestGetAllWeathers()
    {
        weatherForecastRepository.Setup(weather => weather.GetAllQueryable()).Returns(weatherForecasts.AsQueryable());

        var weatherForecastService = new WeatherForecastService(weatherForecastRepository.Object);
        var weatherList = weatherForecastService.GetAllWeathers();

        Assert.IsTrue(weatherList.Count == 4);
        Assert.IsTrue(weatherList.All(s => s.Date < DateTime.Now));
    }
}
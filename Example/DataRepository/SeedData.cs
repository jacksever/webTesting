using System;
using System.Collections.Generic;
using System.Linq;
using Example.BusinessLogic;
using Example.DataAccess;
using Microsoft.Extensions.DependencyInjection;

namespace Example.DataRepository;

public static class SeedData
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        var service = new WeatherForecastService(serviceProvider.GetRequiredService<IEntityRepository<WeatherForecast>>());

        if (service.GetAllWeathers().Any())
            return;

        service.AddWeathers(new List<WeatherForecast>
        {
            new()
            {
                Date = DateTime.Parse("2020-2-12"),
                TemperatureC = 18,
                Summary = "Chilly"
            },
            new()
            {
                Date = DateTime.Parse("2020-2-12"),
                TemperatureC = 34,
                Summary = "Warm"
            },
            new()
            {
                Date = DateTime.Parse("2020-2-12"),
                TemperatureC = -3,
                Summary = "Freezing"
            },
            new()
            {
                Date = DateTime.Parse("2020-2-12"),
                TemperatureC = 17,
                Summary = "Mild"
            }
        });
    }
}
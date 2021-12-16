using System;
using System.Collections.Generic;
using System.Linq;
using Example.DataAccess;
using Example.DataRepository;

namespace Example.BusinessLogic;

public class WeatherForecastService
{
    private IEntityRepository<WeatherForecast> _repository { get; set; }

    public WeatherForecastService(IEntityRepository<WeatherForecast> repository)
    {
        _repository = repository;
    }

    public List<WeatherForecast> GetAllWeathers()
    {
        return _repository.GetAllQueryable().ToList();
    }

    public void AddWeathers(List<WeatherForecast> items)
    {
        foreach (var item in items)
            _repository.Insert(item);
    }
}
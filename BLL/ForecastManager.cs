using System;
using System.Collections.Generic;
using DAL;
using Model;

namespace BLL
{
    public class ForecastManager
    {
        private ForecastRepository _forecastRepository = new ForecastRepository();

        public IEnumerable<WeatherForecast> GetForecasts()
        {
            return _forecastRepository.GetForecasts();
        }

        public void SaveForecast(WeatherForecast forecast)
        {
            _forecastRepository.SaveForecast(forecast);
        }

        public void DeleteForecast(int id)
        {
            _forecastRepository.DeleteForecast(id);
        }
    }
}
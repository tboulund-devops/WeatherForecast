using System;
using System.Collections.Generic;
using DAL;
using Model;

namespace BLL
{
    public class ForecastManager
    {
        private ForecastRepository _forecastRepository = new ForecastRepository();

        public IEnumerable<WeatherForecast> GetForecasts(string password)
        {
            return _forecastRepository.GetForecasts(password);
        }

        public void SaveForecast(string password, WeatherForecast forecast)
        {
            _forecastRepository.SaveForecast(password, forecast);
        }

        public void DeleteForecast(string password, int id)
        {
            _forecastRepository.DeleteForecast(password, id);
        }
    }
}
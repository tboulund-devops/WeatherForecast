using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Model;
using Dapper;

namespace DAL
{
    public class ForecastRepository
    {
        private IDbConnection GetConnection()
        {
            return new SqlConnection($"Server=devops.setgo.dk,8092;Initial Catalog=WeatherForecast;User ID=sa;Password=yourStrongP@ssword;MultipleActiveResultSets=True;");
        }
        
        public IEnumerable<WeatherForecast> GetForecasts()
        {
            var connection = GetConnection();
            return connection.Query<WeatherForecast>("SELECT Id, [Date], TemperatureC, Summary FROM Forecasts");
        }

        public void SaveForecast(WeatherForecast forecast)
        {
            var connection = GetConnection();
            if (forecast.Id == 0)
            {
                connection.Execute(
                    "INSERT INTO Forecasts ([Date], TemperatureC, Summary) VALUES (GETDATE(), @TemperatureC, @Summary)", forecast);
            }
            else
            {
                connection.Execute(
                    "UPDATE Forecasts SET TemperatureC = @TemperatureC, Summary = @Summary WHERE Id = @Id", forecast);
            }
        }

        public void DeleteForecast(int id)
        {
            var connecton = GetConnection();
            connecton.Execute("DELETE FROM Forecasts WHERE Id = @Id", new { Id = id });
        }
    }
}
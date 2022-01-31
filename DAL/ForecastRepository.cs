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
        private IDbConnection GetConnection(string password)
        {
            return new SqlConnection($"Server=tcp:devops-22.database.windows.net,1433;Initial Catalog=WeatherForecast;Persist Security Info=False;User ID=boulund;Password={password};MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
        }
        
        public IEnumerable<WeatherForecast> GetForecasts(string password)
        {
            var connection = GetConnection(password);
            return connection.Query<WeatherForecast>("SELECT Id, [Date], TemperatureC, Summary FROM Forecasts");
        }

        public void SaveForecast(string password, WeatherForecast forecast)
        {
            var connection = GetConnection(password);
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

        public void DeleteForecast(string password, int id)
        {
            var connecton = GetConnection(password);
            connecton.Execute("DELETE FROM Forecasts WHERE Id = @Id", new { Id = id });
        }
    }
}
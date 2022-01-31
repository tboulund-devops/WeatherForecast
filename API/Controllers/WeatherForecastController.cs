using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Model;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private ForecastManager _forecastManager = new ForecastManager();
        
        [HttpGet]
        public IEnumerable<WeatherForecast> Get(string databasePassword)
        {
            return _forecastManager.GetForecasts(databasePassword);
        }

        [HttpPost]
        public void Post([FromBody]PostForecastModel model)
        {
            _forecastManager.SaveForecast(model.DatabasePassword, new WeatherForecast { Summary = model.Summary, TemperatureC = model.TemperatureC});
        }

        [HttpDelete]
        public void Delete([FromBody]DeleteForecastModel model)
        {
            _forecastManager.DeleteForecast(model.DatabasePassword, model.Id);
        }
    }
}
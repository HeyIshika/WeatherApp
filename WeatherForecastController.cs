using System.Runtime.CompilerServices;
using Microsoft.AspNetCore.Mvc;

namespace WeatherForecastAPI
{
    [ApiController, Route("api/[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private IAccuWeatherService accuWeatherService;
        public  WeatherForecastController(IAccuWeatherService accuWeatherService){
            this.accuWeatherService  = accuWeatherService;
        }

        [HttpGet("getCurrentWeather/{cityName}")]
        public async Task<ActionResult<CurrentWeather>> GetCurrentWeather(string cityName){
            return await this.accuWeatherService.GetCurrentWeather(cityName);
        } 
    }
} 
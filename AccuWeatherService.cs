using Microsoft.AspNetCore.Components.Endpoints;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace WeatherForecastAPI
{
    public class AccuWeatherService : IAccuWeatherService
    {
        IRestClient restClient;
        public AccuWeatherService(IRestClient restClient){
            this.restClient = restClient;
        }

        private readonly string host_url = "http://dataservice.accuweather.com/";
        private readonly string apiKey = "UMtffaArSnOYMZH10Xm2PH4tG30yfS5x";
        public async Task<CurrentWeather> GetCurrentWeather(string cityName)
        {
            var locationKey = await this.GetLocationKeyByCityNameAsync(cityName);
            string endPoint = $"/currentconditions/v1/{locationKey.First().Key}?apikey={apiKey}&details=true";
            string url = host_url + endPoint;
            var httpResponse = await this.restClient.SendRequestAsync(url, HttpMethod.Get, cityName);
            var content = httpResponse.Content.ReadAsStringAsync();
            var obj =  (JArray)JsonConvert.DeserializeObject(content.Result);
            return new CurrentWeather { City = locationKey.First().LocalizedName, CurrentTemperature = obj[0]?.SelectToken("Temperature.Metric.Value") + "°C" , FeelsLikeDescription = obj[0]?.SelectToken("WeatherText")?.ToString()};
        }

        async Task<IEnumerable<LocationKeyModel>> GetLocationKeyByCityNameAsync(string cityName)
        {
            string endPoint = $"locations/v1/search?q={cityName}&apikey={apiKey}";
            string url = host_url + endPoint;
            var httpResponse = await this.restClient.SendRequestAsync(url, HttpMethod.Get, cityName);
            var content = httpResponse.Content.ReadAsStringAsync();
            return  JsonConvert.DeserializeObject<IEnumerable<LocationKeyModel>>(content.Result);
        }
    }
}
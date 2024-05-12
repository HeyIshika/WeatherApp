public interface IAccuWeatherService{
    public Task<CurrentWeather> GetCurrentWeather(string cityname);
}
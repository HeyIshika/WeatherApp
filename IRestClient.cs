namespace WeatherForecastAPI
{
    public interface IRestClient
    {
        Task<HttpResponseMessage> SendRequestAsync(string url, HttpMethod httpMethod, string content);
    }
}
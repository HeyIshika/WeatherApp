using System.Text;

namespace WeatherForecastAPI
{
    public class RestClient : IRestClient
    {
        public async Task<HttpResponseMessage> SendRequestAsync(string url, HttpMethod httpMethod, string content)
        {
            HttpClient client = new()
            {
                BaseAddress = new Uri(url)
            };
            HttpRequestMessage sendRequest = new HttpRequestMessage(httpMethod, client.BaseAddress);
            sendRequest.Content = new StringContent(content,
                                                Encoding.UTF8,
                                                "application/json");

            return await client.SendAsync(sendRequest);
        }
    }
}
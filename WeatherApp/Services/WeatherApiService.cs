using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using WeatherApp.Options;

namespace WeatherApp.Services
{
    public class WeatherApiService : IWeatherApiService
    {
        public string BaseUrl { get; set; }
        public string ApiKey { get; set; }

        private HttpClient httpClient;

        public WeatherApiService(IHttpClientFactory httpClientFactory, IOptions<WeatherApiOption> options)
        {
            BaseUrl = options.Value.BaseUrl;
            ApiKey = options.Value.ApiKey;

            httpClient = httpClientFactory.CreateClient();
        }

        public async Task<WeatherApiResponse> SearchByTitleAsync(string title)
        {
            var response = await httpClient.GetAsync($"{BaseUrl}weather?q={title}&appid={ApiKey}&units=metric");
            var json = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<WeatherApiResponse>(json);
            //if (result.Response == "False")
            //{
            //    throw new Exception(result.Error);
            //}
            return result;
        }
    }
}

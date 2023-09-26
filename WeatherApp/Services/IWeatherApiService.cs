namespace WeatherApp.Services
{
    public interface IWeatherApiService
    {
        Task<WeatherApiResponse> SearchByTitleAsync(string title);
    }
}

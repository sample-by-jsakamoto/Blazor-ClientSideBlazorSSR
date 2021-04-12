using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using ClientSideBlazorSSR.Shared;

namespace ClientSideBlazorSSR.Client.Services
{
    public class ClientSideWeatherForecastService : IWeatherForecastService
    {
        private readonly HttpClient _httpClient;

        public ClientSideWeatherForecastService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public Task<IEnumerable<WeatherForecast>> GetForecastAsync()
        {
            return _httpClient.GetFromJsonAsync<IEnumerable<WeatherForecast>>("WeatherForecast");
        }
    }
}

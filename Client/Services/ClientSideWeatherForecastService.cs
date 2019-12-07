using System.Net.Http;
using System.Threading.Tasks;
using ClientSideBlazorSSR.Shared;
using Microsoft.AspNetCore.Components;

namespace ClientSideBlazorSSR.Client.Services
{
    public class ClientSideWeatherForecastService : IWeatherForecastService
    {
        private readonly HttpClient httpClient;

        public ClientSideWeatherForecastService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public Task<WeatherForecast[]> GetForecastAsync()
        {
            return this.httpClient.GetJsonAsync<WeatherForecast[]>("WeatherForecast");
        }
    }
}

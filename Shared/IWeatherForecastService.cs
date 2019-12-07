using System.Threading.Tasks;

namespace ClientSideBlazorSSR.Shared
{
    public interface IWeatherForecastService
    {
        Task<WeatherForecast[]> GetForecastAsync();
    }
}
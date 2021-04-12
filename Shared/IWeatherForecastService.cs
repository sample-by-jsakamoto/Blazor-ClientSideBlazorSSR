using System.Collections.Generic;
using System.Threading.Tasks;

namespace ClientSideBlazorSSR.Shared
{
    public interface IWeatherForecastService
    {
        Task<IEnumerable<WeatherForecast>> GetForecastAsync();
    }
}
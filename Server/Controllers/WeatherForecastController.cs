using ClientSideBlazorSSR.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ClientSideBlazorSSR.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly IWeatherForecastService weatherForecastService;

        private readonly ILogger<WeatherForecastController> logger;

        public WeatherForecastController(IWeatherForecastService weatherForecastService, ILogger<WeatherForecastController> logger)
        {
            this.weatherForecastService = weatherForecastService;
            this.logger = logger;
        }

        [HttpGet]
        public Task<WeatherForecast[]> Get()
        {
            return weatherForecastService.GetForecastAsync();
        }
    }
}

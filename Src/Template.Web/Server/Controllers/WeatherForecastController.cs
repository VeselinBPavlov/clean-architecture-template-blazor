using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Template.Application.WeatherForecasts.Queries.GetWeatherForecasts;

namespace Template.Server.Controllers
{
    [Authorize]
    public class WeatherForecastController : ApiControllerBase
    {
        [HttpGet]
        public async Task <IEnumerable<WeatherForecast>> Get()
        {
            return await Mediator.Send(new GetWeatherForecastsQuery());
        }
    }
}
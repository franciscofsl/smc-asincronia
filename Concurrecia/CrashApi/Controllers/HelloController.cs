using Microsoft.AspNetCore.Mvc;

namespace CrashApi.Controllers;

[ApiController]
[Route("[controller]")]
public class HelloController : ControllerBase
{
    private readonly ILogger<WeatherForecastController> _logger;

    public HelloController(ILogger<WeatherForecastController> logger)
    {
        _logger = logger;
    }

    [HttpGet(Name = "GetHello")]
    public string Get()
    {
        return "Hello";
    }
}

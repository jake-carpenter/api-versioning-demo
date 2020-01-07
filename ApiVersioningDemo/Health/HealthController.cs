using Microsoft.AspNetCore.Mvc;

namespace ApiVersioningDemo.Health
{
    [ApiVersionNeutral]
    [Route("v{apiVersion:int}/health")]
    [Route("health")]
    public class HealthController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get() => Ok();
    }
}

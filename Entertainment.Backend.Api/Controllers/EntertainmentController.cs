using Microsoft.AspNetCore.Mvc;

namespace Entertainment.Backend.Api.Controllers
{
    [ApiController]
    [Route("api/v1/[Controller]")]
    public class EntertainmentController : BaseController
    {
        private readonly ILogger<EntertainmentController> _logger;

        public EntertainmentController(ILogger<EntertainmentController> logger) =>
            (_logger) = logger;

        [HttpGet("Test")]
        public string GetTest()
        {
            return "Service running";
        }
    }
}

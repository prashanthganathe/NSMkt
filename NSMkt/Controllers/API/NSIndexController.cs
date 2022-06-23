

namespace NSMkt.Controllers.API
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using NSMkt.Handlers;

    [Route("api/[controller]")]
    [ApiController]
    public class NSIndexController : ControllerBase
    {
        [ApiKey]
        [HttpGet("[action]/{city}")]
        public IActionResult City(string city)
        {
            return Ok(new { Temp = "12", Summary = "Barmy", City = city });
        }
    }
}

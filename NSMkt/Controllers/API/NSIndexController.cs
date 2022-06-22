using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace NSMkt.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class NSIndexController : ControllerBase
    {
        [HttpGet("[action]/{city}")]
        public IActionResult City(string city)
        {
            return Ok(new { Temp = "12", Summary = "Barmy", City = city });
        }
    }
}

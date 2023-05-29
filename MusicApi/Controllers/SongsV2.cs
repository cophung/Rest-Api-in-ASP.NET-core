using Microsoft.AspNetCore.Mvc;

namespace MusicApi.Controllers
{
    [ApiController]
    [Route("api/SongsVersion")]
    [ApiVersion("2.0")]
    public class SongsV2 : ControllerBase
    {
        //[MapToApiVersion("2.0")]
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("Songs Version 2.0");
        }
    }
}

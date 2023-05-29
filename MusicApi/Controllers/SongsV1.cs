using Microsoft.AspNetCore.Mvc;

namespace MusicApi.Controllers
{
    [ApiController]
    [Route("api/SongsVersion")]
    [ApiVersion("1.0")]
    public class SongsV1 : ControllerBase
    {
        //[MapToApiVersion("1.0")]
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("Songs Version 1.0");
        }
    }
}

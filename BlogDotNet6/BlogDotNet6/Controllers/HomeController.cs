using Microsoft.AspNetCore.Mvc;

namespace BlogDotNet6.Controllers
{ 

    [ApiController]
    public class HomeController : ControllerBase
    {   
        

        [HttpGet("/")]
        public IActionResult Index()
        {
            return Ok("Hello World");
        }
    }
}
using BlogDotNet6.Attributes;
using Microsoft.AspNetCore.Mvc;

namespace BlogDotNet6.Controllers
{ 

    [ApiController]
    [ApiKey]
    public class HomeController : ControllerBase
    {   
        

        [HttpGet("/")]
        public IActionResult Index()
        {
            return Ok("Hello World");
        }
    }
}
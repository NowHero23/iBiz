using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebShopProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetSomeData()
        {
            var users = new[]
            {
                new{Name = "Some"},
                new{Name = "Data"}
            };
            return Ok(users);
        }
    }
}

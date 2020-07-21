using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BookStoresApplication.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : Controller
    {
        // GET: /<controller>/
        [Route("Index"), HttpGet]
        public IActionResult Index()
        {
            return Ok("Token is Valid");
        }
    }
}

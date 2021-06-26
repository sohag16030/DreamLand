using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Auth.Demo.Controllers
{
    public class NameController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromBody] UserCred userCred)
        {
            return Ok();
        }
    }
}

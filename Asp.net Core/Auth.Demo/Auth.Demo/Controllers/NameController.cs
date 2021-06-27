using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Auth.Demo.Controllers
{
    public class NameController : Controller
    {
        private readonly IJwtAuthenticationManager jwtAuthenticationManager;
        
        public NameController(IJwtAuthenticationManager jwtAuthenticationManager)
        {
            this.jwtAuthenticationManager = jwtAuthenticationManager;
        }
        
        [HttpGet]
        [Route("api/test")]
        public IActionResult Hello()
        {
            return Ok("hello");
        }

        [HttpPost]
        [Route("api/getAuthenticate")]
        public IActionResult Authenticate([FromBody] UserCred userCred)
        {
          var token =  jwtAuthenticationManager.Authenticate(userCred.UserName, userCred.Password);
            if (token == null)
                return Unauthorized();
            else
                return Ok(token);

        }

    }
}

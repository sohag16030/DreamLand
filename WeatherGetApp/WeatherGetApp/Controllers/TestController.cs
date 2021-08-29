using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeatherGetApp.IRepository;

namespace WeatherGetApp.Controllers
{
    [Route("[controller]")]
    public class TestController : Controller
    {
        private readonly ITest _iRepository;
        public TestController(ITest iRepository)
        {
            _iRepository = iRepository;
        }

        [HttpGet]
        [Route("{searchCritera}")]
        public IActionResult GetData(string CityName)
        {
            var result = _iRepository.GetWeatherInfo(CityName);
            return Ok();
        }
    }
}

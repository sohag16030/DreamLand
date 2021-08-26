using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ThirdPartyAPIcall.Service;

namespace ThirdPartyAPIcall.Controllers
{
    [Route("v1/giphy")]
    public class GiphyController : Controller
    {
        private readonly IGiphyServices _giphyServices;
        public GiphyController(IGiphyServices giphyServices)
        {
            _giphyServices = giphyServices;
        }

        [HttpGet]
        [Route("random/{searchCritera}")]
        public IActionResult GetRandomGif(string searchCritera)
        {
            var result = _giphyServices.GetRandomGifBasedOnSearchCritera(searchCritera);
            return Ok();
        }
    }
}

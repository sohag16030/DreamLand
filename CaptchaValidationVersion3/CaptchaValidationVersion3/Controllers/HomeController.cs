using CaptchaValidationVersion3.Models;
using GoogleReCaptcha.V3.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace CaptchaValidationVersion3.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICaptchaValidator _captchaValidator;

        public HomeController(ICaptchaValidator captchaValidator)
        {
            _captchaValidator = captchaValidator;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(SampleViewModel collection, string captcha)
        {
            if (!await _captchaValidator.IsCaptchaPassedAsync(captcha))
            {
                ModelState.AddModelError("captcha", "Captcha validation failed");
            }
            if (ModelState.IsValid)
            {
                ViewData["Message"] = "Success";
            }
            return View(collection);
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreManagementSystem.Controllers
{
    public class TrashAndRecoveryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

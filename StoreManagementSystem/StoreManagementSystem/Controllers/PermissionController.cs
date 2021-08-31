using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreManagementSystem.Controllers
{
    public class PermissionController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

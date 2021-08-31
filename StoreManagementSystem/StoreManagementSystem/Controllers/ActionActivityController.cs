using Microsoft.AspNetCore.Mvc;
using StoreManagementSystem.DbContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreManagementSystem.Controllers
{
    public class ActionActivityController : Controller
    {
        private readonly MyDbContext _context;
        
        [HttpGet]
        public IActionResult AddProductActivity(string val)
        {
            
            return View();
        }
    }
}

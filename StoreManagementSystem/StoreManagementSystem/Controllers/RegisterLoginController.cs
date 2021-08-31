using Microsoft.AspNetCore.Mvc;
using StoreManagementSystem.DbContexts;
using StoreManagementSystem.IRepository;
using StoreManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreManagementSystem.Controllers
{
    [Controller]
    public class RegisterLoginController : Controller
    {
        private readonly MyDbContext _context;
        private readonly IUser _IRepository;

        public RegisterLoginController(MyDbContext context, IUser IRepository)
        {
            _context = context;
            _IRepository = IRepository;
        }

        [HttpGet]
        public IActionResult Register()
        {
            var model = new User();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Register(User model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _IRepository.AddUser(model);

                    return Redirect("Login");
                }

                catch (Exception ex)
                {
                    return Redirect("Register");
                }
            }
            return RedirectToAction("Login");
        }
        [HttpGet]
        public IActionResult Login()
        {
            var model = new User();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Login(User model)
        {
            try
            {
                await _IRepository.Login(model);
                if(model.UserRole == "Admin" || model.UserRole == "admin")
                  return Redirect("/User/Index");
                else
                    return Redirect("/Product/Index");
            }

            catch (Exception ex)
            {
                return Redirect("/RegisterLogin/Register");
            }

        }
    }
}

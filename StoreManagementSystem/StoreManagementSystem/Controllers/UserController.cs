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
    public class UserController : Controller
    {
        private readonly MyDbContext _context;
        private readonly IUser _IRepository;

        public UserController(MyDbContext context, IUser IRepository)
        {
            _context = context;
            _IRepository = IRepository;
        }

        [HttpGet]
        public IActionResult AddUser()
        {
            var model = new User();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddUser(User model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _IRepository.AddUser(model);

                    return RedirectToAction("Index");
                }

                catch (Exception ex)
                {
                    return Redirect("/User/AddUser");
                }
            }
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> EditUser(int id)
        {
            var model = new User();
            model = await _IRepository.LoadUser(id);
            return View(model);
        }

        [HttpPut]
        public IActionResult EditUser(User model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _IRepository.EditUser(model);
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    return Redirect("/User/EditUser");
                }
            }
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> DetailsUser(int id)
        {
            var model = new User();
            model = await _IRepository.LoadUser(id);
            return View(model);
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteUser(int id)
        {
            await _IRepository.DeActivateUser(id);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Index()
        {
            List<User> Users = _context.Users.Where(x => x.Active == true).ToList();
            return View(Users);
        }
    }
}

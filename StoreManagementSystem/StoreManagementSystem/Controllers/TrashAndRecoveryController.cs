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
    public class TrashAndRecoveryController : Controller
    {
        private readonly MyDbContext _context;
        private readonly IProduct _IRepository;
        private readonly IUser _iRepository;
        public TrashAndRecoveryController(MyDbContext context, IProduct IRepository, IUser iRepository)
        {
            _context = context;
            _IRepository = IRepository;
            _iRepository = iRepository;
        }
        [HttpGet]
        public IActionResult InactiveProductList()
        {
            List<Product> products = _context.Products.Where(x => x.Active == false).ToList();
            return View(products);
        }
        [HttpGet]
        public async Task<IActionResult> EditInactiveProduct(int id)
        {
          
            var model = new Product();
            model = await _IRepository.LoadProduct(id);
            return View(model);
        }
        [HttpPost]
        public IActionResult EditInactiveProduct(Product model)
        {
            try
            {
                _IRepository.EditDeletedProduct(model);
                return RedirectToAction("InactiveProductList");
            }
            catch (Exception ex)
            {
                return Redirect("/Home/Customexception");
            }
        }
        [HttpGet]
        public IActionResult InactiveUserList()
        {
            List<User> users = _context.Users.Where(x => x.Active == false).ToList();
            return View(users);
        }
        [HttpGet]
        public async Task<IActionResult> EditInactiveUser(int id)
        {

            var model = new User();
            model = await _iRepository.LoadUser(id);
            return View(model);
        }
        [HttpPost]
        public IActionResult EditInactiveUser(User model)
        {
            try
            {
                _iRepository.EditInactiveUser(model);
                return RedirectToAction("InactiveProductList");
            }
            catch (Exception ex)
            {
                return Redirect("/Home/CustomexceptionforUser");
            }
        }

    }
}

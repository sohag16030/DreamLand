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
    public class ProductController : Controller
    {
        private readonly MyDbContext _context;
        private readonly IProduct _IRepository;
        public ProductController(MyDbContext context, IProduct IRepository)
        {
            _context = context;
            _IRepository = IRepository;
        }
        [HttpGet]
        public async Task<IActionResult> AddProduct()
        {
            try
            {
                var check =await Task.FromResult((from a in _context.ActionActivities where a.ActionId == 1 select a).FirstOrDefault());
                if (check.ActionStatus == false)
                {
                    return Redirect("/Home/Exception");
                }
                var model = new Product();
                return View(model);
            }
            catch (Exception ex)
            {
                return Redirect("/Home/Customexception");
            }

        }

        [HttpPost]
        public async Task<IActionResult> AddProduct(Product model)
        {
            try
            {
                await _IRepository.AddProduct(model);
                return RedirectToAction("Index");
            }

            catch (Exception ex)
            {
                return Redirect("/Home/Customexception");
            }
        }
        [HttpGet]
        public async Task<IActionResult> EditProduct(int id)
        {
            var check = await Task.FromResult((from a in _context.ActionActivities where a.ActionId == 2 select a).FirstOrDefault());
            if (check.ActionStatus == false)
            {
                return Redirect("/Home/Exception");
            }
            var model = new Product();
            model = await _IRepository.LoadProduct(id);
            return View(model);
        }

        [HttpPost]
        public IActionResult EditProduct(Product model)
        {
            try
            {
                _IRepository.EditProduct(model);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return Redirect("/Home/Customexception");
            }
        }
        
        [HttpGet]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var check = await Task.FromResult((from a in _context.ActionActivities where a.ActionId == 3 select a).FirstOrDefault());
            if (check.ActionStatus == false)
            {
                return Redirect("/Home/Exception");
            }
            await _IRepository.DeActivateProduct(id);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> DetailsProduct(int id)
        {
            var check = await Task.FromResult((from a in _context.ActionActivities where a.ActionId == 4 select a).FirstOrDefault());
            if (check.ActionStatus == false)
            {
                return Redirect("/Home/Exception");
            }
            var model = new Product();
            model = await _IRepository.LoadProduct(id);
            return View(model);
        }
        [HttpGet]
        public IActionResult Index()
        {
            List<Product> products = _context.Products.Where(x => x.Active == true).ToList();
            return View(products);
        }
    }
}

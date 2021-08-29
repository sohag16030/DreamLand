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
        public IActionResult AddProduct()
        {
            var model = new Product();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddProduct(Product model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _IRepository.AddProduct(model);

                    return RedirectToAction("Index");
                }

                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> EditProduct(int id)
        {
            var model = new Product();
            model =await _IRepository.LoadProduct(id);
            return View(model);
        }

        [HttpPost]
        public IActionResult EditProduct(Product model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _IRepository.EditProduct(model);
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> DetailsProduct(int id)
        {
            var model = new Product();
            model = await _IRepository.LoadProduct(id);
            return View(model);
        }
        [HttpPut]
        public async Task<IActionResult> DeleteStudent(int id)
        {
            await _IRepository.DeActivateProduct(id);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Index()
        {
            List<Product> products = _context.Products.Where(x=>x.Active == true).ToList();
            return View(products);
        }
    }
}

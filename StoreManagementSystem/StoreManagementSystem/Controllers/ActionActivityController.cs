using Microsoft.AspNetCore.Mvc;
using StoreManagementSystem.DbContexts;
using StoreManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreManagementSystem.Controllers
{
    public class ActionActivityController : Controller
    {
        private readonly MyDbContext _context;
        public ActionActivityController(MyDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Active(int id)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var status = (from x in _context.ActionActivities where x.AutoId == id select x).FirstOrDefault();
                    status.ActionStatus = true;
                    _context.Update(status);
                    await _context.SaveChangesAsync();
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    return Redirect("Index");
                }
            }
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> Inactive(int id)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var status = (from x in _context.ActionActivities where x.AutoId == id select x).FirstOrDefault();
                    status.ActionStatus = false;
                    _context.Update(status);
                    await _context.SaveChangesAsync();
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    return Redirect("Index");
                }
            }
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Index()
        {
            List<ActionActivity> list = _context.ActionActivities.ToList();
            return View(list);
        }
    }
}

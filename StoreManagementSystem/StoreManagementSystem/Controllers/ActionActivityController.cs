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
        public IActionResult Index()
        {
            List<ActionActivity> list = _context.ActionActivities.ToList();
            return View(list);
        }
        [HttpPut]
        public IActionResult Active(int actionId)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var status = (from x in _context.ActionActivities where x.ActionId == actionId select x).FirstOrDefault();
                    status.ActionStatus =true ;
                    _context.Update(status);
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    return Redirect("Index");
                }
            }
            return RedirectToAction("Index");
        }
        [HttpPut]
        public IActionResult InActive(int actionId)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var status = (from x in _context.ActionActivities where x.ActionId == actionId select x).FirstOrDefault();
                    status.ActionStatus = false;
                    _context.Update(status);
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    return Redirect("Index");
                }
            }
            return RedirectToAction("Index");
        }
    }
}

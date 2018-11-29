using Microsoft.AspNet.Identity;
using PES.Models;
using PES.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PES.WebMVC.Controllers
{
    [Authorize]
    public class WeekDataController : Controller
    {
        // GET: WeekData
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new WeekDataService(userId);
            var model = service.GetWeekDatas();
            return View(model);
        }

        // GET: WeekData/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: WeekData/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: WeekData/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(WeekDataCreate model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new WeekDataService(userId);

            service.CreateWeekData(model);

            return RedirectToAction("Index");

        }

        // GET: WeekData/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: WeekData/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: WeekData/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: WeekData/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}

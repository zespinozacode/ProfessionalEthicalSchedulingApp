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
    public class DayController : Controller
    {
        // GET: Day
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new DayService(userId);
            var model = service.GetDays();
            return View(model);
        }

        // GET: Day/Details/5
        public ActionResult Details(int id)
        {
            var svc = CreateDayService();
            var model = svc.GetDayById(id);
            return View(model);
        }

        // GET: Day/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Day/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(DayCreate model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var service = CreateDayService();

            if (service.CreateDay(model))
            {
                TempData["SaveResult"] = "Data saved!";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "There was an error saving the data.");
            return View(model);
        }

        private DayService CreateDayService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new DayService(userId);
            return service;
        }

        // GET: Day/Edit/5
        public ActionResult Edit(int id)
        {
            var service = CreateDayService();
            var detail = service.GetDayById(id);
            var model =
                new DayEdit
                {
                    DayId = detail.DayId,
                    WeekDay = detail.WeekDay,
                    Sales = detail.Sales
                };
            return View(model);
        }

        // POST: Day/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, DayEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if(model.DayId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreateDayService();

            if (service.UpdateDay(model))
            {
                TempData["SaveResult"] = "Your data was updated!";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your not could not be updated.");
            return View();
        }

        // GET: Day/Delete/5
        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateDayService();
            var model = svc.GetDayById(id);

            return View(model);
        }

        // POST: Day/Delete/5
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteDay(int id)
        {
            var service = CreateDayService();

            service.DeleteDay(id);

            TempData["SaveResult"] = "Your note was deleted";

            return RedirectToAction("Index");
            
        }
    }
}

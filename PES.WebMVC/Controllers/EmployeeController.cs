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
    public class EmployeeController : Controller
    {
        // GET: Employee
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new EmployeeService(userId);
            var model = service.GetEmployees();
            return View(model);
        }

        // GET: Employee/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Employee/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(EmployeeCreate model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var service = CreateEmployeeService();

            if (service.CreateEmployee(model))
            {
                TempData["SaveResult"] = "Employee added!";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Employee could not be created.");

            return View(model);
        }

        private EmployeeService CreateEmployeeService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new EmployeeService(userId);
            return service;
        }

        // GET: Details
        public ActionResult Details(int id)
        {
            var svc = CreateEmployeeService();
            var model = svc.GetEmployeeById(id);

            return View(model);
        }

        // GET: Employee/Edit/5
        public ActionResult Edit(int id)
        {
            var service = CreateEmployeeService();
            var detail = service.GetEmployeeById(id);
            var model =
                new EmployeeEdit
                {
                    EmployeeId = detail.EmployeeId,
                    AvailableHours = detail.AvailableHours,
                    Rating = detail.Rating,
                    Name = detail.Name,
                    WageAmount = detail.WageAmount
                };
            return View(model);
        }

        // POST: Employee/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, EmployeeEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if(model.EmployeeId != id)
            {
                ModelState.AddModelError("", "Identification Mismatch");
                return View(model);
            }

            var service = CreateEmployeeService();

            if (service.UpdateEmployee(model))
            {
                TempData["SaveResult"] = "Employee updated!";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Employee could not be updated");
            return View(model);
        }

        // GET: Employee/Delete/5
        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateEmployeeService();
            var model = svc.GetEmployeeById(id);

            return View(model);
        }

        //POST: Employee/Delete/5
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateEmployeeService();

            service.DeleteEmployee(id);

            TempData["SaveResult"] = "Employee Removed.";

            return RedirectToAction("Index");
        }
    }
}

using JobBuddy.Models;
using JobBuddy.Repositories;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JobBuddy.Controllers
{
    [Authorize(Roles = "Admin,HR")]
    public class HrDetailsController : Controller
    {
        private HrDetailsRepository _hrRepository = new HrDetailsRepository();

        public ActionResult Index()
        {
            var id = User.Identity.GetUserId();
            var hrs = _hrRepository.GetHrs(id);
            return View(hrs);
        }

        public ActionResult Create()
        {
            var hr = new HrUserDetails();
            return View(hr);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Create(HrUserDetails hr)
        {
            if (ModelState.IsValid)
            {
                hr.ApplicationUserId = User.Identity.GetUserId();

                _hrRepository.AddHr(hr);

                return RedirectToAction("Index");
            }

            else
            {
                return View(hr);
            };
        }


        public ActionResult Edit(Guid id)
        {
            var hr = _hrRepository.FindHrById(id);
            return View(hr);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(HrUserDetails hr)
        {
            if (ModelState.IsValid)
            {
                hr.ApplicationUserId = User.Identity.GetUserId();
                _hrRepository.UpdateHr(hr);

                return RedirectToAction("Index");
            }
            else
            {
                return View(hr);
            }

        }

        public ActionResult Delete(Guid id)
        {
            var hr = _hrRepository.FindHrById(id);
            return View(hr);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteHr(Guid id)
        {
            _hrRepository.DeleteHr(id);
            return RedirectToAction("Index");
        }
               
        public ActionResult Details(Guid id)
        {
            return View(_hrRepository.FindHrById(id));
        }
    }
}
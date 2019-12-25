using JobBuddy.Models;
using JobBuddy.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JobBuddy.Controllers
{
    public class HrDetailsController : Controller
    {
        private HrDetailsRepository _hrRepository = new HrDetailsRepository();

        public ActionResult Index()
        {
            var hrs = _hrRepository.GetHrs();
            return View(hrs);
        }

        public ActionResult Create()
        {
            var hr = new HrDetail();
            return View(hr);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Create(HrDetail hr)
        {
            if (ModelState.IsValid)
            {
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
        public ActionResult Edit(HrDetail hr)
        {
            if (ModelState.IsValid)
            {
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
        public ActionResult DeleteMentor(Guid id)
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
using JobBuddy.Models;
using JobBuddy.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JobBuddy.Controllers
{
    public class JobListingsController : Controller
    {

        private JobListingsRepository _jobListingsRepository = new JobListingsRepository();

        public ActionResult Index()
        {
            var jobListing = _jobListingsRepository.GetJobListings();
            return View(jobListing);
        }

        public ActionResult Create()
        {
            var jobListing = new JobListing();
            return View(jobListing);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Create(JobListing jobListing)
        {
            if (ModelState.IsValid)
            {
                _jobListingsRepository.AddJobListing(jobListing);

                return RedirectToAction("Index");
            }

            else
            {
                return View(jobListing);
            };
        }


        public ActionResult Edit(Guid id)
        {
            var jobListing = _jobListingsRepository.FindJobListingById(id);
            return View(jobListing);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(JobListing jobListing)
        {
            if (ModelState.IsValid)
            {
                _jobListingsRepository.UpdateJobListing(jobListing);

                return RedirectToAction("Index");
            }
            else
            {
                return View(jobListing);
            }

        }

        public ActionResult Delete(Guid id)
        {
            var jobListing = _jobListingsRepository.FindJobListingById(id);
            return View(jobListing);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteMentor(Guid id)
        {
            _jobListingsRepository.DeleteJobListing(id);
            return RedirectToAction("Index");
        }

        public ActionResult Details(Guid id)
        {
            return View(_jobListingsRepository.FindJobListingById(id));
        }
    }
}
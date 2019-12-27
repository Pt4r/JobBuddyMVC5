using JobBuddy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JobBuddy.Controllers
{
    public class JobCategoryController : Controller
    {
        private readonly JobCategoriesRepository _jobCategoryRepository = new JobCategoriesRepository();
        // GET: JobCategory
        public ActionResult Index()
        {
            return View(_jobCategoryRepository.GetJobCategory());
        }

       
        [HttpGet]
        public ActionResult Create()
        {
            JobCategory jobCategory = new JobCategory();
            return View(jobCategory);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(JobCategory jobCategory)
        {
            if (!ModelState.IsValid)
            {
                return View(jobCategory);
            }

            _jobCategoryRepository.AddJobCategory(jobCategory);

            return RedirectToAction("Index");
        }

        public ActionResult Edit(Guid id)
        {
            var jobCategory = _jobCategoryRepository.FindById(id);
            return View(jobCategory);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(JobCategory jobCategory)
        {
            if (!ModelState.IsValid)
            {
                return View(jobCategory);
            }

            _jobCategoryRepository.UpdateJobCategory(jobCategory);

            return RedirectToAction("Index");
        }

       
        public ActionResult Delete(Guid id)
        {
            return View(_jobCategoryRepository.FindById(id));
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirm(Guid id)
        {
            _jobCategoryRepository.DeleteGenre(id);
            return RedirectToAction("Index");
        }
    }
}

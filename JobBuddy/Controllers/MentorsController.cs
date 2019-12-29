using JobBuddy.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JobBuddy.Models;
using Microsoft.AspNet.Identity;

namespace JobBuddy.Controllers
{
    public class MentorsController : Controller
    {
        public string IdFromUser;
        // GET: Mentors
        private MentorRepository _mentorRepository = new MentorRepository();
        
        public ActionResult Index()
        {
            //id = IdFromUser;
            var id = User.Identity.GetUserId();
            var mentors = _mentorRepository.GetMentors(id);
            
            return View(mentors);
        }

        public ActionResult Create()
        {
            var mentor = new MentorDetails();
            
            return View(mentor);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Create(MentorDetails mentor)
        {
            if(ModelState.IsValid)
            {

                mentor.ApplicationUserId = User.Identity.GetUserId();

                _mentorRepository.AddMentor(mentor);

                return RedirectToAction("Index");
            }

            else
            {
                return View(mentor);
            };
        }

        public ActionResult Delete(Guid id)
        {
            var mentor = _mentorRepository.FindMentorbyId(id);
            return View(mentor);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteMentor(Guid id)
        {
            _mentorRepository.DeleteMentor(id);
            return RedirectToAction("Index");
        }

        public ActionResult Edit(Guid id)
        {
            var mentor = _mentorRepository.FindMentorbyId(id);
            return View(mentor);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(MentorDetails mentor)
        {
            if (ModelState.IsValid)
            {
                _mentorRepository.UpdateMentor(mentor);

               return RedirectToAction("Index");
            }
            else
            {
                return View(mentor);
            }
            
        }

        public ActionResult Details(Guid id)
        {
            return View(_mentorRepository.FindMentorbyId(id));
        }

    }
}
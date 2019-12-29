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
    [Authorize(Roles = "Admin,Mentor")]
    public class MentorsController : Controller
    {
        // GET: Mentors
        private readonly MentorRepository _mentorRepository = new MentorRepository();
        

        public ActionResult Index()
        {
            // filtrarw by AspnetuserId
            var id = User.Identity.GetUserId();
            var mentors = _mentorRepository.GetMentors(id);
            return View(mentors);
        }

        public ActionResult Create()
        {
            var mentor = new MentorUserDetails();
            return View(mentor);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Create(MentorUserDetails mentorUser)
        {
            if(ModelState.IsValid)
            {
                //Sto create prin prosthesw to neo mentor stin basi kaataxwrw san foreignkey to AspnetuserId 
                mentorUser.ApplicationUserId = User.Identity.GetUserId();
                _mentorRepository.AddMentor(mentorUser);

                return RedirectToAction("Index");
            }

            else
            {
                return View(mentorUser);
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
        public ActionResult Edit(MentorUserDetails mentorUser)
        {
            if (ModelState.IsValid)
            {
                mentorUser.ApplicationUserId = User.Identity.GetUserId();

                _mentorRepository.UpdateMentor(mentorUser);

               return RedirectToAction("Index");
            }
            else
            {
                return View(mentorUser);
            }
            
        }

        public ActionResult Details(Guid id)
        {
            return View(_mentorRepository.FindMentorbyId(id));
        }

    }
}
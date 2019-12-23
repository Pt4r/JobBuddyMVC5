using JobBuddy.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JobBuddy.Models;

namespace JobBuddy.Controllers
{
    public class MentorsController : Controller
    {
        // GET: Mentors
        private MentorRepository _mentorRepository = new MentorRepository();
        
        public ActionResult Index()
        {
            var mentors = _mentorRepository.GetMentors();
            return View(mentors);
        }


    }
}
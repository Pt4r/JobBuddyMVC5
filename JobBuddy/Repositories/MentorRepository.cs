using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using JobBuddy.Models;
using System.Data.Entity;

namespace JobBuddy.Repositories
{
    public class MentorRepository
    {
        //prostheto parametro to id tou Aspnetuser
        public IEnumerable<MentorUserDetails> GetMentors(string Id)
        {
            IEnumerable<MentorUserDetails> mentors;

            using (var db=new ApplicationDbContext())
            {
                //Allazw to search me basi to Id tou Logged in user ...Wste na fortwnw se kathe login mono ta dedomena tou xristi//
                mentors = db.Mentors.Include(m=>m.ApplicationUser).Where(m => m.ApplicationUserId == Id).ToList();
            }

            return mentors;
        }

        public void AddMentor(MentorUserDetails mentorUser)
        {
            if (mentorUser == null)
            {
                throw new ArgumentNullException();
            }
            using (var db = new ApplicationDbContext())
            {
                mentorUser.MentorId = Guid.NewGuid();
                db.Mentors.Add(mentorUser);
                db.SaveChanges();
            }
        }


        public void UpdateMentor(MentorUserDetails mentorUser)
        {
            if (mentorUser == null)
            {
                throw new ArgumentNullException();
            }
            using (var db = new ApplicationDbContext())
            {
                db.Mentors.Attach(mentorUser);
                db.Entry(mentorUser).State = EntityState.Modified;
                db.SaveChanges();
            }
        }

        public void DeleteMentor(Guid id)
        {
            using (var db = new ApplicationDbContext())
            {
                var deletedMentor=db.Mentors.SingleOrDefault(m => m.MentorId == id);
                if(deletedMentor==null)
                {
                    throw new ArgumentNullException();
                }
                else
                {
                    db.Mentors.Remove(deletedMentor);
                    db.SaveChanges();
                }
               
            }

        }

        public MentorUserDetails FindMentorbyId(Guid id)
        {
            MentorUserDetails mentorUserFound;

            using (var db = new ApplicationDbContext())
            {
                mentorUserFound = db.Mentors.SingleOrDefault(m => m.MentorId == id);
              
            }

            return mentorUserFound;
        }

    }
}
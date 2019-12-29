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
        public IEnumerable<MentorDetails> GetMentors(string Id)
        {
            
            IEnumerable<MentorDetails> mentors;

            using (var db=new ApplicationDbContext())
            {
                mentors = db.Mentors.Where(m => m.ApplicationUserId == Id).ToList();
            }

            return mentors;
        }

        public void AddMentor(MentorDetails mentor)
        {
            if (mentor == null)
            {
                throw new ArgumentNullException();
            }
            using (var db = new ApplicationDbContext())
            {
                mentor.MentorId = Guid.NewGuid();
                db.Mentors.Add(mentor);
                db.SaveChanges();
            }
        }


        public void UpdateMentor(MentorDetails mentor)
        {
            if (mentor == null)
            {
                throw new ArgumentNullException();
            }
            using (var db = new ApplicationDbContext())
            {
                db.Mentors.Attach(mentor);
                db.Entry(mentor).State = EntityState.Modified;
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

        public MentorDetails FindMentorbyId(Guid id)
        {
            MentorDetails mentorFound;

            using (var db = new ApplicationDbContext())
            {
                mentorFound = db.Mentors.SingleOrDefault(m => m.MentorId == id);
              
            }

            return mentorFound;
        }

    }
}
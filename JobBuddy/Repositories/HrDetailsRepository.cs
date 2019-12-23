using JobBuddy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JobBuddy.Repositories
{
    public class HrDetailsRepository
    {

        public IEnumerable<HrDetail> GetHrDetails()
        {
            IEnumerable<HrDetail> hrDetails;

            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                hrDetails = db.HrDetails.ToList();
            }
            return hrDetails;
        }

        public void AddHrDetail(Company company, int phoneno, byte  profpic)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                db.HrDetails.Add(new HrDetail
                {
                    HrCompany = company,
                    PhoneNumber = phoneno,
                    ProfilePic = profpic
                });
                db.SaveChanges();
            }
        }

        public void UpdateHrDetail(HrDetail hrDetail)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                db.HrDetails.Attach(hrDetail);
                db.Entry(hrDetail).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
        }

        public void DeleteHrDetail(int id)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                var artist = db.HrDetails.Find(id);
                db.HrDetails.Remove(artist);
                db.SaveChanges();
            }
        }

        public HrDetail FindById(int id)
        {
            HrDetail hrDetail;
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                hrDetail = db.HrDetails.Find(id);
            }
            return hrDetail;
        }
    }

}
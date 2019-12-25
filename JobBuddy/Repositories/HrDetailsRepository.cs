using JobBuddy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JobBuddy.Repositories
{
    public class HrDetailsRepository
    {

        public IEnumerable<HrDetail> GetHrs()
        {
            IEnumerable<HrDetail> hrDetails;

            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                hrDetails = db.HrDetails.ToList();
            }
            return hrDetails;
        }


        public void AddHr(HrDetail hrDetail)
        {
            if (hrDetail == null)
            {
                throw new ArgumentNullException();
            }
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                hrDetail.Id = Guid.NewGuid();
                db.HrDetails.Add(hrDetail);
                db.SaveChanges();
            }
        }

        public void UpdateHr(HrDetail hrDetail)
        {
            if (hrDetail == null)
            {
                throw new ArgumentNullException();
            }
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                db.HrDetails.Attach(hrDetail);
                db.Entry(hrDetail).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
        }

        public void DeleteHr(Guid id)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                var hrDetail = db.HrDetails.Find(id);
                db.HrDetails.Remove(hrDetail);
                db.SaveChanges();
            }
        }

        public HrDetail FindHrById(Guid id)
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
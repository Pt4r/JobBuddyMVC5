using JobBuddy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JobBuddy.Repositories
{
    public class HrDetailsRepository
    {
        //prostheto parametro to id tou Aspnetuser
        public IEnumerable<HrUserDetails> GetHrs(string Id)
        {
            IEnumerable<HrUserDetails> hrDetails;

            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                //Allazw to search me basi to Id tou Logged in user ...Wste na fortwnw se kathe login mono ta dedomena tou xristi//
                hrDetails = db.HRs.Where(m => m.ApplicationUserId == Id).ToList();
            }
            return hrDetails;
        }


        public void AddHr(HrUserDetails hrDetail)
        {
            if (hrDetail == null)
            {
                throw new ArgumentNullException();
            }
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                hrDetail.Id = Guid.NewGuid();
                db.HRs.Add(hrDetail);
                db.SaveChanges();
            }
        }

        public void UpdateHr(HrUserDetails hrDetail)
        {
            if (hrDetail == null)
            {
                throw new ArgumentNullException();
            }
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                db.HRs.Attach(hrDetail);
                db.Entry(hrDetail).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
        }

        public void DeleteHr(Guid id)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                var hrDetail = db.HRs.Find(id);
                db.HRs.Remove(hrDetail);
                db.SaveChanges();
            }
        }

        public HrUserDetails FindHrById(Guid id)
        {
            HrUserDetails hrDetail;
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                hrDetail = db.HRs.Find(id);
            }
            return hrDetail;
        }
    }

}
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
                hrDetails = db.Artists.ToList();
            }

            return artists;
        }

        public void AddArtist(string name)
        {
            Throw.IfNullOrWhiteSpace(name, "Name cannot be null or whitespace");

            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                db.Artists.Add(new Artist
                {
                    Name = name
                });

                db.SaveChanges();
            }
        }

        public void UpdateArtist(Artist artist)
        {
            Throw.IfNull(artist, nameof(artist));

            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                db.Artists.Attach(artist);
                db.Entry(artist).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
        }

        public void DeleteArtist(int id)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                var artist = db.Artists.Find(id);
                db.Artists.Remove(artist);
                db.SaveChanges();
            }
        }

        public Artist FindById(int id)
        {
            Artist artist;
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                artist = db.Artists.Find(id);
            }

            return artist;
        }
    }
    }
}
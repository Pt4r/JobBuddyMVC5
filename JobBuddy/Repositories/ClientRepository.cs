using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using JobBuddy.Models;

namespace JobBuddy.Repositories
{
    public class ClientRepository
    {
        public IEnumerable<ClientUserDetails> GetClients()
        {
            IEnumerable<ClientUserDetails> clients;

            using (var db = new ApplicationDbContext())
            {
                clients = db.Clients.ToList();
            }

            return clients;
        }
    }
}
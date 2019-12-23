using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JobBuddy.Models;
using JobBuddy.Repositories;

namespace JobBuddy.Controllers
{
    public class ClientsController : Controller
    {
        private readonly ClientRepository _clientRepository = new ClientRepository();

        // GET: Gigs
        public ActionResult Index()
        {
            var clients = _clientRepository.GetClients();
            return View(clients);
        }

        public ActionResult Create()
        {
            ClientCreateViewModel vm = new ClientCreateViewModel();
            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ClientCreateViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                return View(vm);
            }

            _clientRepository.AddClient(vm.Client);

            return RedirectToAction("Index");
        }

        public ActionResult Delete(Guid id)
        {
            return View(_clientRepository.FindById(id));
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirm(Guid id)
        {
            _clientRepository.DeleteClient(id);
            return RedirectToAction("Index");
        }

        public ActionResult Edit(Guid id)
        {
            var client = _clientRepository.FindById(id);
            ClientCreateViewModel vm = new ClientCreateViewModel();
            vm.Client = client;

            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ClientCreateViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                return View(vm);
            }

            _clientRepository.UpdateClient(vm);

            return RedirectToAction("Index");
        }

        public ActionResult Details(Guid id)
        {
            return View(_clientRepository.FindById(id));
        }
    }
}
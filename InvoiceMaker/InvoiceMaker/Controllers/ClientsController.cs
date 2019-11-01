using InvoiceMaker.FormModels;
using InvoiceMaker.Models;
using InvoiceMaker.Repositories;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Web.Mvc;

namespace InvoiceMaker.Controllers
{
    public class ClientsController : BaseController
    {
        public ActionResult Index()
        {
            var repo = new ClientRepository(_context);
            List<Client> clients = repo.GetClients();
            return View(clients);
        }

        public ActionResult Create()
        {
            var formModel = new CreateClient();
            formModel.IsActivated = true;
            return View(formModel);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Create(CreateClient formModel)
        {
            var repo = new ClientRepository(_context);
            try
            {
                Client newClient = new Client(formModel.Name, formModel.IsActivated);
                repo.Insert(newClient);
                return RedirectToAction("Index");
            }
            catch
            {
                ModelState.AddModelError("Name", "Unable to add client.");
            }

            return View(formModel);
        }

        public ActionResult Edit(int id)
        {
            var repo = new ClientRepository(_context);
            var client = repo.GetById(id);
            var formModel = new EditClient
            {
                Id = client.Id,
                Name = client.Name,
                IsActivated = client.IsActive
            };
            return View(formModel);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Edit(int id, EditClient formModel)
        {
            var repo = new ClientRepository(_context);
            try
            {
                var newClient = new Client(id, formModel.Name, formModel.IsActivated);
                repo.Update(newClient);
                return RedirectToAction("Index");
            }
            catch (SqlException se)
            {
                if (se.Number == 2627)
                {
                    ModelState.AddModelError("Name", "That name is already taken.");
                }
            }
            return View(formModel);
        }
    }
}
using InvoiceMaker.FormModels;
using InvoiceMaker.Models;
using InvoiceMaker.Repositories;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Web.Mvc;

namespace InvoiceMaker.Controllers
{
    public class ClientsController : Controller
    {
        public ActionResult Index()
        {
            var repo = new ClientRepository();
            List<Client> clients = repo.GetClients();
            return View(clients);
        }

        public ActionResult Create()
        {
            var formModel = new CreateClient();
            formModel.IsActivated = true;
            return View(formModel);
        }

        [HttpPost]
        public ActionResult Create(CreateClient formModel)
        {
            var repo = new ClientRepository();
            try
            {
                Client newClient = new Client(formModel.Name, formModel.IsActivated);
                repo.Insert(newClient);
                return RedirectToAction("Index");
            }
            catch (SqlException se)
            {
                if (se.Number == 2627)
                {
                    ModelState.AddModelError("Name", "That name is already taken");
                }
            }

            return View(formModel);
        }
    }
}
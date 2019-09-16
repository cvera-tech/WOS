using InvoiceMaker.Models;
using InvoiceMaker.Repositories;
using System.Collections.Generic;
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
    }
}
using InvoiceMaker.FormModels;
using InvoiceMaker.Models;
using InvoiceMaker.Repositories;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InvoiceMaker.Controllers
{
    public class WorksDoneController : Controller
    {
        public ActionResult Index()
        {
            var repo = new WorkDoneRepository();
            List<WorkDone> worksDone = repo.GetWorksDone();
            return View(worksDone);
        }

        public ActionResult Create()
        {
            var clientRepo = new ClientRepository();
            List<Client> clients = clientRepo.GetClients();
            var clientItems = new List<SelectListItem>();
            foreach (var client in clients)
            {
                var item = new SelectListItem
                {
                    Text = client.Name,
                    Value = client.Id.ToString()
                };
                clientItems.Add(item);
            }

            var workTypeRepo = new WorkTypeRepository();
            List<WorkType> workTypes = workTypeRepo.GetWorkTypes();
            var workTypeItems = new List<SelectListItem>();
            foreach (var workType in workTypes)
            {
                var item = new SelectListItem
                {
                    Text = workType.Name,
                    Value = workType.Id.ToString()
                };
                workTypeItems.Add(item);
            }

            var formModel = new CreateWorkDone
            {
                ClientItems = clientItems,
                WorkTypeItems = workTypeItems
            };

            return View(formModel);
        }

        [HttpPost]
        public ActionResult Create(CreateWorkDone formModel)
        {
            var repo = new WorkDoneRepository();
            try
            {
                var client = new Client(formModel.ClientId);
                var workType = new WorkType(formModel.WorkTypeId);
                var workDone = new WorkDone(client, workType, formModel.StartedOn, formModel.EndedOn);
                repo.Insert(workDone);
                return RedirectToAction("Index");
            }
            catch (SqlException se)
            {
                // TODO handle this
                throw se;
            }
        }
    }
}
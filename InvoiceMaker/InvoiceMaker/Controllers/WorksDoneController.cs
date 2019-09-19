using InvoiceMaker.FormModels;
using InvoiceMaker.Models;
using InvoiceMaker.Repositories;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Web.Mvc;

namespace InvoiceMaker.Controllers
{
    public class WorksDoneController : BaseController
    {
        public ActionResult Index()
        {
            var repo = new WorkDoneRepository(_context);
            List<WorkDone> worksDone = repo.GetWorksDone();
            return View(worksDone);
        }

        public ActionResult Create()
        {
            var clientItems = GetClientListItems();
            var workTypeItems = GetWorkTypeItems();
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
            var clientRepo = new ClientRepository(_context);
            var client = new Client(formModel.ClientId);
            //var client = clientRepo.GetById(formModel.ClientId);
            var workTypeRepo = new WorkTypeRepository(_context);
            var workType = new WorkType(formModel.WorkTypeId);
            //var workType = workTypeRepo.GetById(formModel.WorkTypeId);
            var workDone = new WorkDone(client, workType, formModel.StartedOn, formModel.EndedOn);
            try
            {
                var workDoneRepo = new WorkDoneRepository(_context);
                workDoneRepo.Insert(workDone);
                return RedirectToAction("Index");
            }
            catch (SqlException se)
            {
                // TODO handle this
                ModelState.AddModelError("Create", "Unable to add new work done");
                return View(formModel);
            }
        }

        public ActionResult Edit(int id)
        {
            var repo = new WorkDoneRepository(_context);
            var workDone = repo.GetById(id);
            var clientItems = GetClientListItems();
            var workTypeItems = GetWorkTypeItems();
            var formModel = new EditWorkDone()
            {
                Id = id,
                ClientId = workDone.ClientId,
                WorkTypeId = workDone.WorkTypeId,
                StartedOn = workDone.StartedOn,
                EndedOn = workDone.EndedOn,
                ClientItems = clientItems,
                WorkTypeItems = workTypeItems
            };
            return View(formModel);
        }

        [HttpPost]
        public ActionResult Edit(int id, EditWorkDone formModel)
        {
            var repo = new WorkDoneRepository(_context);
            var client = new Client(formModel.ClientId);
            var workType = new WorkType(formModel.WorkTypeId);
            var workDone = new WorkDone(id, client, workType, formModel.StartedOn, formModel.EndedOn);
            try
            {
                repo.Update(workDone);
                return RedirectToAction("Index");
            }
            catch (SqlException se)
            {
                ModelState.AddModelError("Edit", "Unable to update work done");
                return View(formModel);
            }
        }

        /// <summary>
        /// Retrieves the clients from the database and wraps them in
        /// SelectListItems for use with a drop down list.
        /// </summary>
        /// <returns>List of SelectListItem-wrapped WorkTypes</returns>
        private List<SelectListItem> GetClientListItems()
        {
            var repo = new ClientRepository(_context);
            List<Client> clients = repo.GetClients();
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
            return clientItems;
        }

        /// <summary>
        /// Retrieves the work types from the database and wraps them in
        /// SelectListItems for use with a drop down list.
        /// </summary>
        /// <returns>List of SelectListItem-wrapped WorkTypes</returns>
        private List<SelectListItem> GetWorkTypeItems()
        {
            var repo = new WorkTypeRepository(_context);
            List<WorkType> workTypes = repo.GetWorkTypes();
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
            return workTypeItems;
        }
    }
}
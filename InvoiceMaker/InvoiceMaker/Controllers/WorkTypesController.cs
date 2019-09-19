using InvoiceMaker.FormModels;
using InvoiceMaker.Models;
using InvoiceMaker.Repositories;
using System.Data.SqlClient;
using System.Web.Mvc;

namespace InvoiceMaker.Controllers
{
    public class WorkTypesController : BaseController
    {
        public ActionResult Index()
        {
            var repo = new WorkTypeRepository(_context);
            var workTypes = repo.GetWorkTypes();
            return View(workTypes);
        }

        public ActionResult Create()
        {
            var formModel = new CreateWorkType();
            return View(formModel);
        }

        [HttpPost]
        public ActionResult Create(CreateWorkType formModel)
        {
            var repo = new WorkTypeRepository(_context);
            WorkType workType = new WorkType(formModel.Name, formModel.Rate);
            try
            {
                repo.Insert(workType);
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

        public ActionResult Edit(int id)
        {
            var repo = new WorkTypeRepository(_context);
            var workType = repo.GetById(id);
            var formModel = new EditWorkType
            {
                Id = workType.Id,
                Name = workType.Name,
                Rate = workType.Rate
            };
            return View(formModel);
        }

        [HttpPost]
        public ActionResult Edit(int id, EditWorkType formModel)
        {
            var repo = new WorkTypeRepository(_context);
            try
            {
                var newWorkType = new WorkType(id, formModel.Name, formModel.Rate);
                repo.Update(newWorkType);
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
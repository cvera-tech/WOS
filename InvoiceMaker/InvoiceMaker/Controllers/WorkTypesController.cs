using InvoiceMaker.FormModels;
using InvoiceMaker.Models;
using InvoiceMaker.Repositories;
using System.Data.SqlClient;
using System.Web.Mvc;

namespace InvoiceMaker.Controllers
{
    public class WorkTypesController : Controller
    {
        public ActionResult Index()
        {
            var repo = new WorkTypeRepository();
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
            var repo = new WorkTypeRepository();
            try
            {
                WorkType workType = new WorkType(formModel.Name, formModel.Rate);
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
    }
}
using InvoiceMaker.FormModels;
using InvoiceMaker.Repositories;
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
    }
}
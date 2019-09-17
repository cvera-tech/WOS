using InvoiceMaker.FormModels;
using InvoiceMaker.Repositories;
using System.Web.Mvc;

namespace InvoiceMaker.Controllers
{
    public class InvoicesController : Controller
    {
        public ActionResult Index()
        {
            var repo = new InvoiceRepository();
            var invoices = repo.GetInvoices();
            return View(invoices);
        }

        public ActionResult Create()
        {
            var formModel = new CreateInvoice();
            return View(formModel);
        }
    }
}
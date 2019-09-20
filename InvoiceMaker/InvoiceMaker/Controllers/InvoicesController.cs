using InvoiceMaker.FormModels;
using InvoiceMaker.Models;
using InvoiceMaker.Repositories;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Web.Mvc;

namespace InvoiceMaker.Controllers
{
    public class InvoicesController : BaseController
    {
        public ActionResult Index()
        {
            var repo = new InvoiceRepository(_context);
            var invoices = repo.GetInvoices();
            return View(invoices);
        }

        public ActionResult Details(int id)
        {
            var repo = new InvoiceRepository(_context);
            var invoice = repo.GetById(id);
            return View(invoice);
        }

        public ActionResult Create()
        {
            var clientRepo = new ClientRepository(_context);
            var formModel = new CreateInvoice() {
                ClientList = clientRepo.GetSelectListItems()
            };
            return View(formModel);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Create(CreateInvoice formModel)
        {
            var repo = new InvoiceRepository(_context);
            var invoice = new Invoice() {
                ClientId = formModel.ClientId,
                InvoiceNumber = formModel.InvoiceNumber,
                Status = formModel.Status,
                DateOpened = DateTimeOffset.Now
            };
            try
            {
                repo.Insert(invoice);
                return RedirectToAction("Index");
            }
            catch (SqlException se)
            {
                if (se.Number == 2627)
                {
                    ModelState.AddModelError("InvoiceNumber", "That number is already taken.");
                }
            }
            return View(formModel);
        }

        ///// <summary>
        ///// Retrieves the invoice statuses from the database and wraps them in
        ///// SelectListItems for use with a drop down list.
        ///// </summary>
        ///// <returns>List of SelectListItem-wrapped InvoiceStatuses</returns>
        //private List<SelectListItem> GetStatusItems()
        //{
        //    var repo = new InvoiceRepository();
        //    var statusDTOs = repo.GetInvoiceStatusDTOs();
        //    var statusItems = new List<SelectListItem>();
        //    foreach (var dto in statusDTOs)
        //    {
        //        var item = new SelectListItem();
        //        item.Value = dto.Id.ToString();
        //        item.Text = dto.Name;
        //        statusItems.Add(item);
        //    }
        //    return statusItems;
        //}
    }
}
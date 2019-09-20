using InvoiceMaker.FormModels;
using InvoiceMaker.Models;
using InvoiceMaker.Repositories;
using System;
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
            var formModel = new CreateInvoice()
            {
                ClientList = clientRepo.GetSelectListItems()
            };
            return View(formModel);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Create(CreateInvoice formModel)
        {
            var repo = new InvoiceRepository(_context);
            var invoice = new Invoice()
            {
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

        public ActionResult Edit(int id)
        {
            var repo = new InvoiceRepository(_context);
            var invoice = repo.GetById(id);
            var clientRepo = new ClientRepository(_context);
            var formModel = new EditInvoice()
            {
                Id = id,
                ClientId = invoice.ClientId,
                InvoiceNumber = invoice.InvoiceNumber,
                ClientList = clientRepo.GetSelectListItems(),
                DateOpened = invoice.DateOpened
            };
            return View(formModel);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Edit(int id, EditInvoice formModel)
        {
            var invoice = new Invoice()
            {
                Id = id,
                ClientId = formModel.ClientId,
                InvoiceNumber = formModel.InvoiceNumber,
                DateOpened = formModel.DateOpened
            };
            var repo = new InvoiceRepository(_context);
            try
            {
                repo.Update(invoice);
                return RedirectToAction("Details", "Invoices",
                    routeValues: new { id = id });  // This is so weird
            }
            catch (Exception e) // Squashing exceptions is never a good idea
            {
                // TODO Handle exception
                return View(formModel);
            }
        }
    }
}
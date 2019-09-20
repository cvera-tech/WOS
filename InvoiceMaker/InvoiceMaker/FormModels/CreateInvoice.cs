using InvoiceMaker.Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace InvoiceMaker.FormModels
{
    public class CreateInvoice
    {
        public string InvoiceNumber { get; set; }
        public int StatusId { get; set; }
        //public List<SelectListItem> StatusItems { get; set; }
    }
}
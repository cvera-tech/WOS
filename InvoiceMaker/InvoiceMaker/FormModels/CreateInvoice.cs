using InvoiceMaker.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace InvoiceMaker.FormModels
{
    public class CreateInvoice
    {
        [Display(Name = "Invoice Number")]
        public string InvoiceNumber { get; set; }
        [Display(Name = "Client")]
        public int ClientId { get; set; }
        public InvoiceStatus Status { get; set; }

        public List<SelectListItem> ClientList { get; set; }
    }
}
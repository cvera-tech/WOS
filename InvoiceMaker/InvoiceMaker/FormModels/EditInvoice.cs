using InvoiceMaker.Models;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace InvoiceMaker.FormModels
{
    public class EditInvoice
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public string InvoiceNumber { get; set; }
        public DateTimeOffset DateOpened { get; set; }
        public DateTimeOffset? DateFinalized { get; set; }
        public DateTimeOffset? DateClosed { get; set; }
        public InvoiceStatus Status { get; set; }
        public List<SelectListItem> ClientList { get; set; }
    }
}
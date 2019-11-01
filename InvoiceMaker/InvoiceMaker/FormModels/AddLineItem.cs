using InvoiceMaker.Models;
using System;
using System.Collections.Generic;

namespace InvoiceMaker.FormModels
{
    public class AddLineItem
    {
        // Work Line Item
        public int WorkDoneId { get; set; }
        public List<WorkDone> WorkDoneList { get; set; }

        // Fee Line Item
        public string Description { get; set; }
        public DateTimeOffset When { get; set; }
        public decimal Amount { get; set; }
    }
}
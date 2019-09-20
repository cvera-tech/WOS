using System;
using System.Collections.Generic;

namespace InvoiceMaker.Models
{
    public class Invoice
    {
        public int Id { get; set; }
        public string InvoiceNumber { get; set; }
        public DateTimeOffset DateOpened { get; set; }

        // Foreign key properties
        public int ClientId { get; set; }
        public InvoiceStatus Status { get; set; }
        public List<ILineItem> LineItems { get; set; }

        // Navigation properties
        public Client Client { get; set; }

        public Invoice()
        {
            LineItems = new List<ILineItem>();
            Status = InvoiceStatus.Open;
        }

        //public Invoice(int id)
        //{
        //    Id = id;
        //}

        //public Invoice(int id, string invoiceNumber, InvoiceStatus status) : this(invoiceNumber, status)
        //{
        //    Id = id;
        //}

        //public Invoice(string invoiceNumber)
        //{
        //    InvoiceNumber = invoiceNumber;
        //    LineItems = new List<ILineItem>();
        //    Status = InvoiceStatus.Open;
        //}

        //public Invoice(string invoiceNumber, InvoiceStatus status) : this(invoiceNumber)
        //{
        //    Status = status;
        //}

        ///// <summary>
        ///// Create an Invoice object suitable for database operations
        ///// </summary>
        ///// <param name="invoiceNumber">The unique InvoiceNumber</param>
        ///// <param name="statusId">The Id of the status in the database</param>
        //public Invoice(string invoiceNumber, int statusId)
        //{
        //    InvoiceNumber = invoiceNumber;
        //    StatusId = statusId;
        //}

        //public void AddFeeLineItem(string description, decimal amount, DateTimeOffset when)
        //{
        //    var feeLineItem = new FeeLineItem(description, amount, when);
        //    LineItems.Add(feeLineItem);
        //}
        //public void AddWorkLineItem(WorkDone workDone)
        //{
        //    var workLineItem = new WorkLineItem(workDone);
        //    LineItems.Add(workLineItem);
        //}
        //public void CloseInvoice()
        //{
        //    if (Status == InvoiceStatus.Finalized)
        //    {
        //        Status = InvoiceStatus.Closed;
        //    }
        //}
        //public void FinalizeInvoice()
        //{
        //    if (Status == InvoiceStatus.Open)
        //    {
        //        Status = InvoiceStatus.Finalized;
        //    }
        //}
    }
}
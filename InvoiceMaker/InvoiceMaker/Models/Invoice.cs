using System;
using System.Collections.Generic;

namespace InvoiceMaker.Models
{
    public class Invoice
    {
        public int Id { get; private set; }
        public string InvoiceNumber { get; private set; }
        public List<ILineItem> LineItems { get; private set; }
        public InvoiceStatus Status { get; private set; }

        public Invoice(int id)
        {
            Id = id;
        }

        public Invoice(int id, string invoiceNumber, InvoiceStatus status) : this (invoiceNumber, status)
        {
            Id = id;
        }

        public Invoice(string invoiceNumber)
        {
            InvoiceNumber = invoiceNumber;
            LineItems = new List<ILineItem>();
            Status = InvoiceStatus.Open;
        }

        public Invoice(string invoiceNumber, InvoiceStatus status) : this(invoiceNumber)
        {
            Status = status;
        }

        public void AddFeeLineItem(string description, decimal amount, DateTimeOffset when)
        {
            var feeLineItem = new FeeLineItem(description, amount, when);
            LineItems.Add(feeLineItem);
        }
        public void AddWorkLineItem(WorkDone workDone)
        {
            var workLineItem = new WorkLineItem(workDone);
            LineItems.Add(workLineItem);
        }
        public void CloseInvoice()
        {
            if (Status == InvoiceStatus.Finalized)
            {
                Status = InvoiceStatus.Closed;
            }
        }
        public void FinalizeInvoice()
        {
            if (Status == InvoiceStatus.Open)
            {
                Status = InvoiceStatus.Finalized;
            }
        }
    }
}
using System;
using System.Collections.Generic;

namespace InvoiceMaker.Models
{
    public class Invoice
    {
        private string _invoiceNumber;

        public int Id { get; private set; }
        public string InvoiceNumber
        {
            get
            {
                return _invoiceNumber;
            }

            private set
            {
                // Enforce uppercase InvoiceNumber rule
                _invoiceNumber = value.ToUpper() ?? null;
            }
        }
        public List<ILineItem> LineItems { get; private set; }
        public InvoiceStatus Status { get; private set; }
        public int StatusId { get; private set; }

        public Invoice(int id)
        {
            Id = id;
        }

        public Invoice(int id, string invoiceNumber, InvoiceStatus status) : this(invoiceNumber, status)
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

        /// <summary>
        /// Create an Invoice object suitable for database operations
        /// </summary>
        /// <param name="invoiceNumber">The unique InvoiceNumber</param>
        /// <param name="statusId">The Id of the status in the database</param>
        public Invoice(string invoiceNumber, int statusId)
        {
            InvoiceNumber = invoiceNumber;
            StatusId = statusId;
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
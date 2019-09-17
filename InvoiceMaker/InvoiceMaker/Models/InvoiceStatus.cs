using System;

namespace InvoiceMaker.Models
{
    public enum InvoiceStatus
    {
        Open,
        Finalized,
        Closed
    }

    public static class InvoiceStatusExtensions
    {
        public static InvoiceStatus ToInvoiceStatus(this String statusName)
        {
            // We want to throw an exception if the string cannot be parsed
            return (InvoiceStatus)(Enum.Parse(typeof(InvoiceStatus), statusName));
        }
    }
}
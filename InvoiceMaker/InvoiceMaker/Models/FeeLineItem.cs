using System;

namespace InvoiceMaker.Models
{
    public class FeeLineItem : ILineItem
    {
        public int Id { get; set; }

        public decimal Amount { get; set; }
        public string Description { get; set; }
        public DateTimeOffset When { get; set; }
    }
}
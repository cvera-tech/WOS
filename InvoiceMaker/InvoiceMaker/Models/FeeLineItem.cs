using System;

namespace InvoiceMaker.Models
{
    public class FeeLineItem : ILineItem
    {
        public decimal Amount { get; private set; }
        public string Description { get; private set; }
        public DateTimeOffset When { get; private set; }

        public FeeLineItem(string description, decimal amount, DateTimeOffset when)
        {
            Amount = amount;
            Description = description;
            When = when;
        }
    }
}
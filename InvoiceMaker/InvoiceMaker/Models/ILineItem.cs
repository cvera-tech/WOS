using System;

namespace InvoiceMaker.Models
{
    public interface ILineItem
    {
        decimal Amount { get; }
        string Description { get; }
        DateTimeOffset When { get; }
    }
}
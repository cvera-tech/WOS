using System;

namespace InvoiceMaker.Models
{
    public class WorkLineItem : ILineItem
    {
        public int Id { get; set; }

        // Foreign key properties
        public int WorkDoneId { get; set; }

        // Navigation properties
        public WorkDone WorkDone { get; set; }

        public decimal Amount
        {
            get
            {
                return WorkDone.GetTotal() ?? 0;
            }
        }
        public string Description
        {
            get
            {
                return WorkDone.WorkType.Name;
            }
        }
        public DateTimeOffset When
        {
            get
            {
                return WorkDone.StartedOn;
            }
        }
    }
}
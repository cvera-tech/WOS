using System;

namespace InvoiceMaker.Models
{
    public class WorkLineItem : ILineItem
    {
        public int WorkDoneId { get; set; }
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
using System;

namespace InvoiceMaker.Models
{
    public class WorkLineItem : ILineItem
    {
        private WorkDone _workDone;
        public decimal Amount
        {
            get
            {
                return _workDone.GetTotal() ?? 0;
            }
        }
        public string Description
        {
            get
            {
                return _workDone.WorkType.Name;
            }
        }
        public DateTimeOffset When
        {
            get
            {
                return _workDone.StartedOn;
            }
        }

        public WorkLineItem(WorkDone workDone)
        {
            _workDone = workDone;
        }
    }
}
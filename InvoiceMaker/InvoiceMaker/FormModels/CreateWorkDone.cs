using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace InvoiceMaker.FormModels
{
    public class CreateWorkDone
    {
        public int ClientId { get; set; }
        public int WorkTypeId { get; set; }
        public DateTimeOffset StartedOn { get; set; }
        public DateTimeOffset? EndedOn { get; set; }
        public List<SelectListItem> ClientItems { get; set; }
        public List<SelectListItem> WorkTypeItems { get; set; }
    }
}
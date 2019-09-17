using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InvoiceMaker.Models
{
    /// <summary>
    /// This class acts as a data transfer object for the data that is required 
    /// to construct a WorkDone object. This is because the DatabaseHelper 
    /// class cannot set non-SQL data type properties.
    /// </summary>
    public class WorkDoneDTO
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public int WorkTypeId { get; set; }
        public DateTimeOffset StartedOn { get; set; }
        public DateTimeOffset EndedOn { get; set; }
        public string ClientName { get; set; }
        public bool IsActivated { get; set; }
        public string WorkTypeName { get; set; }
        public decimal Rate { get; set; }
    }
}
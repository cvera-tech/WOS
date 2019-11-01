using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InvoiceMaker.Models
{
    /// <summary>
    /// This class acts as a data transfer object for the data that is required 
    /// to construct an Invoice object. This is because the DatabaseHelper 
    /// class cannot set non-SQL data type properties.
    /// </summary>
    public class InvoiceDTO
    {
        public int Id { get; set; }
        public string InvoiceNumber { get; set; }
        public string StatusName { get; set; }
    }
}
using System;

namespace InvoiceMaker.Models
{
    public class InvoiceStatusDTO
    {
        public int Id { get; private set; }
        public string Name { get; private set; }

        public InvoiceStatusDTO() { }

        public InvoiceStatusDTO(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public InvoiceStatus InvoiceStatus
        {
            get
            {
                return (InvoiceStatus)(Enum.Parse(typeof(InvoiceStatus), Name));
            }
        }
    }
}
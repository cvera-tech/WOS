using InvoiceMaker.Data;
using InvoiceMaker.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace InvoiceMaker.Repositories
{
    public class InvoiceRepository : BaseRepository
    {
        public InvoiceRepository(Context context) : base(context) { }

        public List<Invoice> GetInvoices()
        {
            var invoices = _context.Invoices
                .Include(i => i.Client)
                .ToList();
            return invoices;
        }

        public Invoice GetById(int id)
        {
            var invoice = _context.Invoices
                .Include(i => i.Client)
                .SingleOrDefault(i => i.Id == id);
            return invoice;
        }

        public void Insert(Invoice invoice)
        {
            _context.Invoices.Add(invoice);
            _context.SaveChanges();
        }

        //public List<InvoiceStatusDTO> GetInvoiceStatusDTOs()
        //{
        //    string sql = @"
        //        SELECT 
        //            Id, Name
        //        FROM
        //            InvoiceStatus
        //        ORDER BY
        //            Id
        //    ";

        //    var statusDTOs = DatabaseHelper.Retrieve<InvoiceStatusDTO>(sql);
        //    return statusDTOs;
        //}
    }
}
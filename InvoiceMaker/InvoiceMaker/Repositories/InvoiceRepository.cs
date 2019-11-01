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

        public void Update(Invoice invoice)
        {
            // SaveChanges is called by the extension method
            _context.UpdateEntity(invoice);
        }
    }
}
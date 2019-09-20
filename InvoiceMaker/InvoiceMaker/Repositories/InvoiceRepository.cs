using InvoiceMaker.Data;
using InvoiceMaker.Models;
using System.Collections.Generic;
using System.Linq;

namespace InvoiceMaker.Repositories
{
    public class InvoiceRepository : BaseRepository
    {
        public InvoiceRepository(Context context) : base(context) { }

        public List<Invoice> GetInvoices()
        {
            var invoices = _context.Invoices
                .ToList();
            return invoices;
        }

        //public Invoice GetById(int id)
        //{
        //    string sql = @"
        //        SELECT
        //            I.Id,
        //            I.InvoiceNumber,
        //            S.Name AS InvoiceStatus
        //        FROM Invoice I
        //            JOIN InvoiceStatus S ON S.Id = I.StatusId
        //    ";
        //    Invoice invoice = DatabaseHelper.RetrieveSingle<Invoice>(sql,
        //        new SqlParameter("@Id", id));
        //    return invoice;
        //}

        //public void Insert(Invoice invoice)
        //{
        //    string sql = @"
        //        INSERT INTO Invoice (InvoiceNumber, StatusId)
        //        VALUES (@InvoiceNumber, @StatusId)
        //    ";
        //    DatabaseHelper.Insert(sql,
        //        new SqlParameter("@InvoiceNumber", invoice.InvoiceNumber),
        //        new SqlParameter("@StatusId", invoice.StatusId));
        //}

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
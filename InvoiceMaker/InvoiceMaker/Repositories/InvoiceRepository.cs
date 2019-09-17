using InvoiceMaker.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InvoiceMaker.Repositories
{
    public class InvoiceRepository
    {
        public List<Invoice> GetInvoices()
        {
            string sql = @"
                SELECT
                    I.Id,
                    I.InvoiceNumber,
                    S.Name AS StatusName
                FROM Invoice I
                    JOIN InvoiceStatus S ON S.Id = I.StatusId
            ";
            var invoiceDTOs = DatabaseHelper.Retrieve<InvoiceDTO>(sql);
            var invoices = new List<Invoice>();
            foreach (var dto in invoiceDTOs)
            {
                var invoice = new Invoice(dto.Id, dto.InvoiceNumber, ToInvoiceStatus(dto.StatusName));
                invoices.Add(invoice);
            }
            return invoices;
        }

        public Invoice GetById(int id)
        {
            string sql = @"
                SELECT
                    I.Id,
                    I.InvoiceNumber,
                    S.Name AS InvoiceStatus
                FROM Invoice I
                    JOIN InvoiceStatus S ON S.Id = I.StatusId
            ";
            Invoice invoice = DatabaseHelper.RetrieveSingle<Invoice>(sql,
                new SqlParameter("@Id", id));
            return invoice;
        }
        //FROM Invoice I
        //            JOIN InvoiceStatus IS ON IS.Id = I.StatusId
        //            LEFT JOIN LineItem LI ON LI.InvoiceId = I.Id    -- Also get invoices without line items
        //            LEFT JOIN WorkDone WD ON LI.WorkDoneId = WD.Id  -- Fee line items have no WorkDoneId

        public void Insert(Invoice invoice)
        {
            string sql = @"
                INSERT INTO Invoice (InvoiceNumber, StatusId)
                VALUES (@InvoiceNumber, @StatusId)
            ";
            DatabaseHelper.Insert(sql,
                new SqlParameter("@InvoiceNumber", invoice.InvoiceNumber),
                new SqlParameter("@StatusId", invoice.Status));
        }

        public List<SelectListItem> GetInvoiceStatusItems()
        {
            string sql = @"
                SELECT 
            ";
            return null;
        }

        private InvoiceStatus ToInvoiceStatus(string statusName)
        {
            // We want an exception to be thrown if parsing fails
            return (InvoiceStatus)(Enum.Parse(typeof(InvoiceStatus), statusName));
        }
    }
}
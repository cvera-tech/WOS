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
        //public List<Invoice> GetInvoices()
        //{
        //    string sql = @"
        //        SELECT
        //            I.Id,
        //            I.InvoiceNumber,
        //            S.Name AS StatusName
        //        FROM Invoice I
        //            JOIN InvoiceStatus S ON S.Id = I.StatusId
        //        ORDER BY I.InvoiceNumber
        //    ";
        //    var invoiceDTOs = DatabaseHelper.Retrieve<InvoiceDTO>(sql);
        //    var invoices = new List<Invoice>();
        //    foreach (var dto in invoiceDTOs)
        //    {
        //        var invoice = new Invoice(dto.Id, dto.InvoiceNumber, dto.StatusName.ToInvoiceStatus());
        //        invoices.Add(invoice);
        //    }
        //    return invoices;
        //}

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
using Library.Data;
using LibraryApplication.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LibraryApplication.Patrons
{
    public partial class List : System.Web.UI.Page
    {
        private const string GetPatronsQuery = @"
            SELECT 
                P.Id,
                P.FirstName,
                P.LastName,
                P.AddressLine1 + ISNULL(' ' + P.AddressLine2, '') + ', ' 
                    + P.City + ', ' + S.Abbreviation + ' ' + P.PostalCode AS Address,
                P.EmailAddress
            FROM Patron P
                JOIN State S
                    ON P.StateId = S.Id
            ORDER BY P.LastName, P.FirstName, P.Id
        ";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DataTable patronsTable = DatabaseHelper.Retrieve(GetPatronsQuery);
                PatronsRepeater.DataSource = patronsTable.Rows;
                PatronsRepeater.DataBind();
            }
        }

        protected void AddButton_Command(object sender, CommandEventArgs e)
        {
            Response.Redirect(SitePages.GetUrl(LibraryPage.AddPatron));
        }
    }
}
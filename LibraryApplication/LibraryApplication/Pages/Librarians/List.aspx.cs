using Library.Data;
using LibraryApplication.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LibraryApplication.Pages.Librarians
{
    public partial class List : System.Web.UI.Page
    {
        private string AddLibrarianUrl = SitePages.GetUrl(LibraryPage.AddLibrarian);
        private const string GetLibrariansQuery = @"
            SELECT
                L1.Id,
	            UA.FirstName,
	            UA.LastName,
	            UA.EmailAddress,
	            L2.Name AS LibraryName,
	            UA.AddressLine1 + ISNULL(' ' + UA.AddressLine2, '') + ', ' + UA.City + ', ' + S.Abbreviation + ' ' + UA.PostalCode AS StreetAddress
            FROM Librarian L1 
	            JOIN Employee E ON L1.EmployeeId = E.Id
	            JOIN Library L2 ON E.LibraryId = L2.Id
	            JOIN UserAccount UA ON E.UserAccountId = UA.Id
	            JOIN State S ON UA.StateId = S.Id
            ORDER BY UA.LastName ASC, UA.FirstName ASC, LibraryName ASC, L1.Id ASC
        ";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!User.IsInRole("Librarian"))
            {
                Response.Redirect(SitePages.GetUrl(LibraryPage.NotAuthorized));
            }

            if (!IsPostBack)
            {
                DataTable librariansTable = DatabaseHelper.Retrieve(GetLibrariansQuery);
                LibrariansRepeater.DataSource = librariansTable.Rows;
                LibrariansRepeater.DataBind();
            }
        }

        protected void AddButton_Command(object sender, CommandEventArgs e)
        {
            Response.Redirect(AddLibrarianUrl);
        }
    }
}
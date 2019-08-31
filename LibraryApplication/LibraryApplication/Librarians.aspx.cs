using Library.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LibraryApplication
{
    public partial class Librarians : System.Web.UI.Page
    {
        private const string AddLibrarianUrl = "~/AddLibrarian.aspx";
        private const string GetLibrariansQuery = @"
            SELECT 
	            E.FirstName,
	            E.LastName,
	            L2.Name AS LibraryName,
	            E.AddressLine1 + 
		            ISNULL(' ' + E.AddressLine2, '') + 
		            ', ' + E.City +
		            ', ' + S.Name +
		            ' ' + E.PostalCode
		            AS Address,
	            E.EmailAddress
            FROM Librarian L1
	            JOIN Employee E
		            ON L1.EmployeeId = E.Id
	            JOIN Library L2
		            ON E.LibraryId = L2.Id
	            JOIN State s
		            ON E.StateId = S.Id
        ";
        protected void Page_Load(object sender, EventArgs e)
        {
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
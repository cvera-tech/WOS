using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LibraryApplication
{
    public partial class AddLibrary : System.Web.UI.Page
    {
        private const string LibrariesUrl = "~/Libraries.aspx";
        private const string AddLibraryQuery = @"
            INSERT INTO Library (Name, AddressLine1, AddressLine2, City, StateId, PostalCode)
            VALUES (
                @Name,
                @AddressLine1,
                @AddressLine2,
                @City,
                @StateId,
                @PostalCode
            )
        ";
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void AddButton_Command(object sender, CommandEventArgs e)
        {
            
        }

        protected void CancelButton_Command(object sender, CommandEventArgs e)
        {
            Response.Redirect(LibrariesUrl);
        }
    }
}
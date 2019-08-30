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
    public partial class Libraries : System.Web.UI.Page
    {
        private const string AddLibraryUrl = "~/AddLibrary.aspx";
        private const string GetLibrariesQuery = @"
            SELECT
                Library.Id,
                Library.Name,
                AddressLine1 + ISNULL(' ' + AddressLine2, '') + ', ' + City + ', ' + State.Name +  ' ' + PostalCode AS Address
            FROM Library JOIN State
            ON Library.StateId = State.Id
        ";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DataTable dt = DatabaseHelper.Retrieve(GetLibrariesQuery);

                LibrariesRepeater.DataSource = dt.Rows;
                LibrariesRepeater.DataBind();
            }
        }

        protected void AddButton_Command(object sender, CommandEventArgs e)
        {
            Response.Redirect(AddLibraryUrl);
        }
    }
}
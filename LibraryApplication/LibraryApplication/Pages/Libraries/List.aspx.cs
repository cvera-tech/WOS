using Library.Data;
using LibraryApplication.Data;
using System;
using System.Data;
using System.Web.UI.WebControls;

namespace LibraryApplication.Pages.Libraries
{
    public partial class List : System.Web.UI.Page
    {
        private string AddLibraryUrl = SitePages.GetUrl(LibraryPage.AddLibrary);
        private const string GetLibrariesQuery = @"
            SELECT
                Library.Id,
                Library.Name,
                AddressLine1 + ISNULL(' ' + AddressLine2, '') + ', ' + City + ', ' + State.Name +  ' ' + PostalCode AS Address
            FROM Library JOIN State
            ON Library.StateId = State.Id
            ORDER BY Library.Name
        ";
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                DataTable dt = DatabaseHelper.Retrieve(GetLibrariesQuery);

                LibrariesRepeater.DataSource = dt.Rows;
                LibrariesRepeater.DataBind();

                AddButton.Visible = User.IsInRole("Librarian");
            }
        }

        protected void AddButton_Command(object sender, CommandEventArgs e)
        {
            Response.Redirect(AddLibraryUrl);
        }
    }
}
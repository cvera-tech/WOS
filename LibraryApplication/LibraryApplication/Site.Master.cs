using LibraryApplication.Data;
using System;
using System.Web.Security;
using System.Web.UI.WebControls;

namespace LibraryApplication
{
    public partial class Site : System.Web.UI.MasterPage
    {
        private const string GetNameQuery = @"
            SELECT FirstName + ' ' + LastName AS Name
            FROM Employee
            WHERE Username = @Username
        ";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                SetNavLinks();
                //    DataTable userTable = DatabaseHelper.Retrieve(GetNameQuery,
                //        new SqlParameter("@Username", LoginName));
                //    if (userTable.Rows.Count == 1)
                //    {
                //        DataRow userRow = userTable.Rows[0];
                //        string name = userRow.Field<string>("Name");
                //        (LoginViewThings.FindControl("NameLabel") as Label).Text = name;
                //    }

                //}
            }
        }

        protected void LogoutButton_Command(object sender, CommandEventArgs e)
        {
            FormsAuthentication.SignOut();
            Response.Redirect("~/Default.aspx");
        }

        /// <summary>
        /// This function programmatically sets the URLs for the HyperLinks in the navigation menu.
        /// This would not be necessary if Web Forms wasn't being so difficult and disallowing 
        /// the use of inline displaying expressions in HyperLink controls.
        /// </summary>
        private void SetNavLinks()
        {
            AuthorsLink.NavigateUrl = SitePages.GetUrl(LibraryPage.Authors);
            BooksLink.NavigateUrl = SitePages.GetUrl(LibraryPage.Books);
            LibrariesLink.NavigateUrl = SitePages.GetUrl(LibraryPage.Libraries);
            LibrariansLink.NavigateUrl = SitePages.GetUrl(LibraryPage.Librarians);
        }
    }
}
using Library.Data;
using LibraryApplication.Data;
using System;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

namespace LibraryApplication.Pages.Authors
{
    public partial class Add : System.Web.UI.Page
    {
        private string AuthorsUrl = SitePages.GetUrl(LibraryPage.Authors);
        private const string SqlQuery = @"
            INSERT INTO Author (FirstName, LastName)
            VALUES (@FirstName, @LastName)
        ";

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void AddButton_Command(object sender, CommandEventArgs e)
        {
            if (Page.IsValid)
            {
                string firstName = FirstName.Text;
                string lastName = LastName.Text;

                int? id = DatabaseHelper.Insert(
                    SqlQuery,
                    new SqlParameter("@FirstName", firstName),
                    new SqlParameter("@LastName", lastName));

                Response.Redirect(AuthorsUrl);
            }
        }

        protected void CancelButton_Command(object sender, CommandEventArgs e)
        {
            Response.Redirect(AuthorsUrl);
        }
    }
}
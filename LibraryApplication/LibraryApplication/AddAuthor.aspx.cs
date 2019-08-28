using Library.Data;
using System;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

namespace LibraryApplication
{
    public partial class AddAuthor : System.Web.UI.Page
    {
        private const string AuthorsUrl = "~/Authors.aspx";
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
using Library.Data;
using LibraryApplication.Data;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

namespace LibraryApplication.Pages.Authors
{
    public partial class Edit : System.Web.UI.Page
    {
        private string AuthorsUrl = SitePages.GetUrl(LibraryPage.Authors);
        private const string GetAuthorQuery = @"
            SELECT FirstName, LastName
            FROM Author
            WHERE Id = @AuthorId
        ";
        private const string UpdateAuthorQuery = @"
            UPDATE Author
            SET
                FirstName = @FirstName,
                LastName = @LastName
            WHERE Id = @AuthorId
        ";

        private int authorId;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!int.TryParse(Request.QueryString["ID"], out authorId))
            {
                Response.Redirect(AuthorsUrl);
            }

            if (!IsPostBack)
            {
                DataTable dt = DatabaseHelper.Retrieve(
                    GetAuthorQuery,
                    new SqlParameter("@AuthorId", authorId));

                if (dt.Rows.Count == 1)
                {
                    string oldFirstName = dt.Rows[0].Field<string>("FirstName");
                    string oldLastName = dt.Rows[0].Field<string>("LastName");
                    OldFirstName.Text = oldFirstName;
                    OldLastName.Text = oldLastName;
                    NewFirstName.Text = oldFirstName;
                    NewLastName.Text = oldLastName;
                }
                else
                {
                    Response.Redirect(AuthorsUrl);
                }
            }
        }

        protected void SaveButton_Command(object sender, CommandEventArgs e)
        {
            string newFirstName = NewFirstName.Text;
            string newLastName = NewLastName.Text;

            DatabaseHelper.Update(
                UpdateAuthorQuery,
                new SqlParameter("@FirstName", newFirstName),
                new SqlParameter("@LastName", newLastName),
                new SqlParameter("@AuthorId", authorId)
            );

            Response.Redirect(AuthorsUrl);
        }

        protected void CancelButton_Command(object sender, CommandEventArgs e)
        {
            Response.Redirect(AuthorsUrl);
        }
    }
}
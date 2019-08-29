using Library.Data;
using System;
using System.Data;

namespace LibraryApplication
{
    public partial class Authors : System.Web.UI.Page
    {
        private const string AddAuthorUrl = "~/AddAuthor.aspx";
        private const string SqlQuery = @"
            SELECT Id, FirstName, LastName
            FROM Author
            ORDER BY LastName, FirstName
        ";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DataTable dt = DatabaseHelper.Retrieve(SqlQuery);

                AuthorsRepeater.DataSource = dt.Rows;
                AuthorsRepeater.DataBind();
            }
        }

        protected void AddButton_Command(object sender, EventArgs e)
        {
            Response.Redirect(AddAuthorUrl);
        }
    }
}
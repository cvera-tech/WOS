using Library.Data;
using LibraryApplication.Data;
using System;
using System.Data;

namespace LibraryApplication.Pages.Authors
{
    public partial class List : System.Web.UI.Page
    {
        private string AddAuthorUrl = SitePages.GetUrl(LibraryPage.AddAuthor);
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
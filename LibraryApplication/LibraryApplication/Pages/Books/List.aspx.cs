using Library.Data;
using LibraryApplication.Data;
using System;
using System.Data;
using System.Web.UI.WebControls;

namespace LibraryApplication.Pages.Books
{
    public partial class List : System.Web.UI.Page
    {
        private string AddBookUrl = SitePages.GetUrl(LibraryPage.AddBook);
        private const string SqlQuery = @"
            SELECT 
                Book.Id, 
                Title, 
                Author.FirstName + ' ' + Author.LastName AS AuthorName, 
                Isbn
            FROM Book JOIN Author
            ON Book.AuthorId = Author.Id
            ORDER BY Author.LastName, Author.FirstName, Title
        ";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DataTable dt = DatabaseHelper.Retrieve(SqlQuery);

                BooksRepeater.DataSource = dt.Rows;
                BooksRepeater.DataBind();

                AddButton.Visible = User.IsInRole("Library");
            }
        }

        protected void AddButton_Command(object sender, CommandEventArgs e)
        {
            Response.Redirect(AddBookUrl);
        }
    }
}
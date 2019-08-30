using Library.Data;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

namespace LibraryApplication
{
    public partial class AddBook : System.Web.UI.Page
    {
        private const string BooksUrl = "~/Books.aspx";
        private const string GetAuthorsQuery = @"
            SELECT Id, LastName + ', ' + FirstName AS AuthorName
            FROM Author
            ORDER BY AuthorName
        ";
        private const string AddBookQuery = @"
            INSERT INTO Book (Title, AuthorId, Isbn)
            VALUES (@Title, @AuthorId, @Isbn)
        ";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DataTable dt = DatabaseHelper.Retrieve(GetAuthorsQuery);
                AuthorDropDown.DataSource = dt;
                AuthorDropDown.DataTextField = "AuthorName";
                AuthorDropDown.DataValueField = "Id";
                AuthorDropDown.DataBind();
            }
        }

        protected void AddButton_Command(object sender, CommandEventArgs e)
        {
            if (Page.IsValid)
            {
                string title = TitleTextBox.Text;
                int authorId = int.Parse(AuthorDropDown.SelectedValue);

                // Isbn is nullable in the database
                string isbn = ISBN.Text;
                if (string.IsNullOrWhiteSpace(isbn))
                {
                    isbn = null;
                }

                // TODO Exception handling
                DatabaseHelper.ExecuteNonQuery(
                    AddBookQuery,
                    new SqlParameter("@Title", title),
                    new SqlParameter("@AuthorId", authorId),
                    DatabaseHelper.GetNullableStringSqlParameter("@Isbn", isbn));
                
                Response.Redirect(BooksUrl);
            }
        }

        protected void CancelButton_Command(object sender, CommandEventArgs e)
        {
            Response.Redirect(BooksUrl);
        }
    }
}
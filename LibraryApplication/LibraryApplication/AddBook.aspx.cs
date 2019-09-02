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
                AuthorDropDown.ListDataSource = () =>
                {
                    DataTable dt = DatabaseHelper.Retrieve(GetAuthorsQuery);
                    AuthorDropDown.SetTextAndValueFields("AuthorName", "Id");
                    return dt;
                };
            }
        }

        protected void AddButton_Command(object sender, CommandEventArgs e)
        {
            if (Page.IsValid)
            {
                string title = TitleTextBox.Text;
                int authorId = int.Parse(AuthorDropDown.SelectedValue);
                string isbn = ISBN.Text;

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
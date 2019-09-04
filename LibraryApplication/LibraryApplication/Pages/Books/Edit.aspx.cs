using Library.Data;
using LibraryApplication.Data;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LibraryApplication.Pages.Books
{
    public partial class Edit : System.Web.UI.Page
    {
        private string BooksUrl = SitePages.GetUrl(LibraryPage.Books);
        private const string GetBookQuery = @"
            SELECT 
                Book.Id AS BookId, 
                Title, 
                Author.Id AS AuthorId,
                Author.FirstName + ' ' + Author.LastName AS AuthorName, 
                Isbn
            FROM Book JOIN Author
            ON Book.AuthorId = Author.Id
            WHERE Book.Id = @BookId
        ";
        private const string GetAuthorsQuery = @"
            SELECT Id, LastName + ', ' + FirstName AS AuthorName
            FROM Author
            ORDER BY AuthorName
        ";
        private const string UpdateBookQuery = @"
            UPDATE Book
            SET
                Title=@Title,
                AuthorId=@AuthorId,
                Isbn=@Isbn
            WHERE Id=@BookId;
        ";
        private int bookId;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!int.TryParse(Request.QueryString["ID"], out bookId))
            {
                Response.Redirect(BooksUrl);
            }

            if (!IsPostBack)
            {
                AuthorDropDown.ListDataSource = () => 
                {
                    DataTable authorsTable = DatabaseHelper.Retrieve(GetAuthorsQuery);
                    AuthorDropDown.SetTextAndValueFields("AuthorName", "Id");
                    return authorsTable;
                };
                DataTable bookTable = DatabaseHelper.Retrieve(
                    GetBookQuery,
                    new SqlParameter("@BookId", bookId));

                if (bookTable.Rows.Count == 1)
                {
                    string oldTitle = bookTable.Rows[0].Field<string>("Title");
                    string oldAuthor = bookTable.Rows[0].Field<string>("AuthorName");
                    string oldIsbn = bookTable.Rows[0].Field<string>("Isbn");
                    int oldAuthorId = bookTable.Rows[0].Field<int>("AuthorId");
                    OldTitle.Text = oldTitle;
                    OldAuthor.Text = oldAuthor;
                    OldIsbn.Text = oldIsbn;
                    TitleTextBox.Text = oldTitle;
                    AuthorDropDown.SelectedValue = oldAuthorId.ToString();
                    IsbnTextBox.Text = oldIsbn;
                }
                else
                {
                    Response.Redirect(BooksUrl);
                }
            }
        }

        protected void SaveButton_Command(object sender, CommandEventArgs e)
        {
            if (Page.IsValid)
            {
                string newTitle = TitleTextBox.Text;
                int newAuthorId = int.Parse(AuthorDropDown.SelectedValue);
                string isbn = IsbnTextBox.Text;

                // TODO Exception handling
                DatabaseHelper.Update(
                    UpdateBookQuery,
                    new SqlParameter("@Title", newTitle),
                    new SqlParameter("@AuthorId", newAuthorId),
                    DatabaseHelper.GetNullableStringSqlParameter(@"Isbn", isbn),
                    new SqlParameter("@BookId", bookId));

                Response.Redirect(BooksUrl);
            }
        }

        protected void CancelButton_Command(object sender, CommandEventArgs e)
        {
            Response.Redirect(BooksUrl);
        }
    }
}
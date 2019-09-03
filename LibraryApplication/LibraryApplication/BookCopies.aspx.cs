using Library.Data;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

namespace LibraryApplication
{
    public partial class BookCopies : System.Web.UI.Page
    {
        private const string BooksUrl = "~/Books.aspx";
        private const string GetBookQuery = @"
            SELECT 
                Title, 
                A.FirstName + ' ' + A.LastName as AuthorName, 
                Isbn
            FROM Book B 
                JOIN Author A 
                    ON B.AuthorId = A.Id
            WHERE B.Id = @BookId
        ";
        private const string GetLibrariesQuery = @"
            SELECT
                Name,
                Id
            FROM
                Library
        ";
        private const string GetBookCopiesQuery = @"
            SELECT
                BC.Id,
	            B.Title,
	            B.Isbn,
	            A.FirstName + ' ' + A.LastName AS AuthorName,
	            L.Name AS LibraryName,
	            BC.Available
            FROM
                BookCopy BC
                JOIN Book B ON BC.BookId = B.Id
	            JOIN Author A ON B.AuthorId = A.Id
	            JOIN Library L ON BC.LibraryId = L.Id
            WHERE B.Id = @BookId
            ORDER BY LibraryName ASC, BC.Available DESC
        ";
        private const string UpdateAvailableQuery = @"
            UPDATE BookCopy
            SET Available = @Available
            WHERE Id = @Id
        ";
        private const string AddBookCopyQuery = @"
            INSERT INTO BookCopy (BookId, LibraryId, Available)
            VALUES (@BookId, @LibraryId, @Available)
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
                DataTable bookTable = DatabaseHelper.Retrieve(GetBookQuery,
                    new SqlParameter("@BookId", bookId));
                if (bookTable.Rows.Count == 1)
                {
                    DataRow bookRow = bookTable.Rows[0];
                    BookTitleLabel.Text = bookRow.Field<string>("Title");
                    AuthorLabel.Text = bookRow.Field<string>("AuthorName");
                    IsbnLabel.Text = bookRow.Field<string>("Isbn");
                }
                
                LibrariesDropDownList.ListDataSource = () => {
                    DataTable librariesTable = DatabaseHelper.Retrieve(GetLibrariesQuery);
                    LibrariesDropDownList.SetTextAndValueFields("Name", "Id");
                    return librariesTable;
                };
            }
        }

        protected void Page_PreRender(object sender, EventArgs e)
        {
            DataTable bookCopiesTable = DatabaseHelper.Retrieve(GetBookCopiesQuery,
               new SqlParameter("@BookId", bookId));
            BookCopiesRepeater.DataSource = bookCopiesTable.Rows;
            BookCopiesRepeater.DataBind();
        }

        protected void Available_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox checkBox = sender as CheckBox;
            bool available = checkBox.Checked;
            RepeaterItem bookCopyRepeaterItem = checkBox.Parent as RepeaterItem;
            Label hiddenLabel = bookCopyRepeaterItem.FindControl("BookCopyId") as Label;
            int bookCopyId = int.Parse(hiddenLabel.Text);
            DatabaseHelper.ExecuteNonQuery(UpdateAvailableQuery,
                new SqlParameter("@Available", available),
                new SqlParameter("@Id", bookCopyId));
        }

        protected void AddButton_Command(object sender, CommandEventArgs e)
        {
            int libraryId = int.Parse(LibrariesDropDownList.SelectedValue);
            bool available = AvailableCheckBox.Checked;

            DatabaseHelper.Insert(AddBookCopyQuery,
                new SqlParameter("@BookId", bookId),
                new SqlParameter("@LibraryId", libraryId),
                new SqlParameter("@Available", available));
        }
    }
}
using Library.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LibraryApplication
{
    public partial class Books : System.Web.UI.Page
    {
        private const string AddBooksUrl = "~/AddBooks.aspx";
        private const string SqlQuery = @"
            SELECT 
                Author.Id, 
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
            }
        }

        protected void AddButton_Command(object sender, CommandEventArgs e)
        {
            Response.Redirect(AddBooksUrl);
        }
    }
}
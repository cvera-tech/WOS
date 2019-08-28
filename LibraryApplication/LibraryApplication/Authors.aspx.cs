using Library.Data;
using System;
using System.Data;

namespace LibraryApplication
{
    public partial class Authors : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DataTable dt = DatabaseHelper.Retrieve(@"
                    select Id, FirstName, LastName
                    from Author
                    order by LastName, FirstName
                ");

                AuthorsRepeater.DataSource = dt.Rows;
                AuthorsRepeater.DataBind();
            }
        }
    }
}
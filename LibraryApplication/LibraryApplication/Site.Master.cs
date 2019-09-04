using Library.Data;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Web.Security;
using System.Web.UI.WebControls;

namespace LibraryApplication
{
    public partial class Site : System.Web.UI.MasterPage
    {
        private const string GetNameQuery = @"
            SELECT FirstName + ' ' + LastName AS Name
            FROM Employee
            WHERE Username = @Username
        ";
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (!IsPostBack)
            //{
                
            //    DataTable userTable = DatabaseHelper.Retrieve(GetNameQuery,
            //        new SqlParameter("@Username", LoginName));
            //    if (userTable.Rows.Count == 1)
            //    {
            //        DataRow userRow = userTable.Rows[0];
            //        string name = userRow.Field<string>("Name");
            //        (LoginViewThings.FindControl("NameLabel") as Label).Text = name;
            //    }
                
            //}
        }

        protected void LogoutButton_Command(object sender, CommandEventArgs e)
        {
            FormsAuthentication.SignOut();
            Response.Redirect("~/Default.aspx");
        }
    }
}
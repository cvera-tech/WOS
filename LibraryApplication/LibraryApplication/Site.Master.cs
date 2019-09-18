using LibraryApplication.Data;
using System;
using System.Web.Security;
using System.Web.UI.WebControls;

namespace LibraryApplication
{
    public partial class Site : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // DataBind must be called to evaluate inline binding expressions
                NavMenu.DataBind();
            }
        }

        protected void LogoutButton_Command(object sender, CommandEventArgs e)
        {
            FormsAuthentication.SignOut();
            Response.Redirect("~/Default.aspx");
        }
    }
}
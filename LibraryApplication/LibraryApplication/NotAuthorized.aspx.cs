using LibraryApplication.Data;
using System;
using System.Web.Security;
using System.Web.UI.WebControls;

namespace LibraryApplication
{
    public partial class NotAuthorized : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void SwitchButton_Command(object sender, CommandEventArgs e)
        {
            // TODO Attempt to redirect to restricted page after switching accounts
            FormsAuthentication.SignOut();
            Response.Redirect(SitePages.GetUrl(LibraryPage.Home));
        }

        protected void HomeButton_Command(object sender, CommandEventArgs e)
        {
            Response.Redirect(SitePages.GetUrl(LibraryPage.Home));
        }
    }
}
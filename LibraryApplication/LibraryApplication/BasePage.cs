using LibraryApplication.Authentication;

namespace LibraryApplication
{
    public class BasePage : System.Web.UI.Page
    {
        protected CustomPrincipal CustomUser
        {
            get
            {
                return (CustomPrincipal)User;
            }
        }
    }
}
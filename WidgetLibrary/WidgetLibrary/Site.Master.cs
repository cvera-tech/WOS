using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WidgetLibrary
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        private const string ThemeSessionKey = "theme";
        public string Theme
        {
            get
            {
                var theme = HttpContext.Current.Session[ThemeSessionKey] as string;
                return theme ?? "Light";
            }
            set
            {
                HttpContext.Current.Session[ThemeSessionKey] = value;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ThemeDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            Theme = ThemeDropDownList.SelectedValue;
            Response.Redirect(Request.RawUrl);
        }
    }
}
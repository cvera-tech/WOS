using System;
using System.Web.UI;

namespace LibraryApplication
{
    public class Global : System.Web.HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            ScriptManager.ScriptResourceMapping.AddDefinition("jquery",
                new ScriptResourceDefinition
                {
                    Path = "~/Scripts/jquery-3.4.1.min.js",
                    DebugPath = "~/Scripts/jquery-3.4.1.js"
                });
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WidgetLibrary
{
    public class ThemedPage : System.Web.UI.Page
    {
        protected override void OnPreInit(EventArgs e)
        {
            var master = Master as Site;
            if (master != null && !string.IsNullOrEmpty(master.Theme))
            {
                Theme = master.Theme;
            }

            base.OnPreInit(e);
        }
    }
}
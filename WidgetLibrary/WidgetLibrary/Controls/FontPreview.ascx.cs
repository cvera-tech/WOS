using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WidgetLibrary.Data;

namespace WidgetLibrary.Controls
{
    public partial class FontPreview : System.Web.UI.UserControl
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                FontList.DataSource = FontsData.Fonts;
                FontList.DataBind();
                FillerText.Text = FontsData.FillerText;
            }
        }

        protected void FontList_SelectedIndexChanged(object sender, EventArgs e)
        {
            FillerText.Font.Name = FontList.SelectedValue;
        }
    }
}
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
        public string LoremType { get; set; } = "Lorem";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                FontList.DataSource = FontsData.Fonts;
                FontList.DataBind();
                string sampleText = string.Empty;
                switch (LoremType)
                {
                    case "Sagan":
                        sampleText = FontsData.SaganText;
                        break;
                    case "Hipster":
                        sampleText = FontsData.HipsterText;
                        break;
                    case "Pirate":
                        sampleText = FontsData.PirateText;
                        break;
                    default:
                        sampleText = FontsData.LoremText;
                        break;
                }
                FillerText.Text = sampleText;
            }
        }

        protected void FontList_SelectedIndexChanged(object sender, EventArgs e)
        {
            FillerText.Font.Name = FontList.SelectedValue;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WidgetLibrary.Controls
{
    public partial class RenderTime : System.Web.UI.UserControl
    {
        private const string DefaultLabel = "Page rendered at: ";
        private const string DefaultFormat = "M/d/yyyy h:mm tt";

        public string Label { get; set; }
        public string Format { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            MessageLabel.Text = string.IsNullOrWhiteSpace(Label) ? DefaultLabel : Label;
            DateTime currentTime = DateTime.Now;
            TimeLabel.Text = string.IsNullOrWhiteSpace(Format) ? currentTime.ToString(DefaultFormat) : currentTime.ToString(Format);
        }
    }
}
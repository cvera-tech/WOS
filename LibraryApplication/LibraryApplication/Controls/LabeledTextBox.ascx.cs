using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LibraryApplication.Controls
{
    public partial class LabeledTextBox : System.Web.UI.UserControl
    {
        public string Label { get; set; }
        public string Text
        {
            get
            {
                return ControlTextBox.Text;
            }
            set
            {
                ControlTextBox.Text = value;
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ControlLabel.Text = Label;
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LibraryApplication.Controls
{
    public partial class LabeledDropDownList : System.Web.UI.UserControl
    {
        public string Label
        {
            get
            {
                return ControlLabel.Text;
            }
            set
            {
                ControlLabel.Text = value;
            }
        }
        public string ValidationGroup
        {
            get
            {
                return ControlDropDownList.ValidationGroup;
            }
            set
            {
                ControlDropDownList.ValidationGroup = value;
            }
        }
        public DropDownList ListControl
        {
            get
            {
                return ControlDropDownList;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

    }

}
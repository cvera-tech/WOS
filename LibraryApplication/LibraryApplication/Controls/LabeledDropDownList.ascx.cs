using System;
using System.Collections.Generic;
using System.Data;
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
        public string DropDownListClientId
        {
            get
            {
                return ControlDropDownList.ClientID;
            }
        }
        public DropDownList ListControl
        {
            get
            {
                return ControlDropDownList;
            }
        }

        public Func<DataTable> ListDataSource { get; set; }
        public bool PrependEmptyItem { get; set; } = false;
        public string SelectedValue
        {
            get
            {
                return ControlDropDownList.SelectedValue;
            }
        }

        protected void Page_Init(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (PrependEmptyItem)
                {
                    ControlEmptyItem.Enabled = true;
                    ControlDropDownList.AppendDataBoundItems = true;
                }
                else
                {
                    ControlEmptyItem.Enabled = false;
                    ControlDropDownList.AppendDataBoundItems = false;
                }
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ControlDropDownList.DataSource = ListDataSource();
                ControlDropDownList.DataBind();
            }
        }

        public void SetTextAndValueFields(string textField, string valueField)
        {
            ControlDropDownList.DataTextField = textField;
            ControlDropDownList.DataValueField = valueField;
        }
    }
}
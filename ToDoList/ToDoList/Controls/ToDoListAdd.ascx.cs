using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ToDoList.Data;

namespace ToDoList.Controls
{
    public partial class ToDoListAdd : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Submit_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                ToDoItemData.AddItem(Description.Text);
                Description.Text = string.Empty;
            }
            //if (!string.IsNullOrWhiteSpace(Description.Text))
            //{
            //    ErrorMessage.Visible = false;
            //    ToDoItemData.AddItem(Description.Text);
            //    Description.Text = string.Empty;
            //}
            //else
            //{
            //    ErrorMessage.Visible = true;
            //}
        }
    }
}
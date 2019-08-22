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
            if (!IsPostBack)
            {
                PopulateCategories();
            }
        }

        protected void Submit_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                ToDoItemData.AddItem(Description.Text, Category.SelectedValue);
                Description.Text = string.Empty;
            }
        }

        private void PopulateCategories()
        {
            List<string> categories = ToDoItemData.GetCategories();
            Category.DataSource = categories;
            Category.DataBind();
        }
    }
}
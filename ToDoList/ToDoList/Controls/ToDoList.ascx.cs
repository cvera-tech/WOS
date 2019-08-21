using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ToDoList.Data;

namespace ToDoList.Controls
{
    public partial class ToDoList : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            PopulateList();
        }

        protected void TODOs_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            int index = int.Parse(e.CommandArgument.ToString());
            List<ToDoItem> todos = ToDoItemData.GetToDoItems();
            todos[index].Done = true;
            PopulateList();
        }

        private void PopulateList()
        {
            List<ToDoItem> todos = ToDoItemData.GetToDoItems();
            TODOs.DataSource = todos;
            TODOs.DataBind();
        }
    }
}
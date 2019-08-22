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
        public int NumberOfRecordsToDisplay { get; set; } = 5;
        public string CategoryFilter
        {
            get
            {
                object o = ViewState["Category"];
                if (o != null)
                {
                    return o.ToString();
                }
                else
                {
                    return "ALL";
                }
            }
            set
            {
                ViewState["Category"] = value;
            }
        }

        private List<ToDoItem> ListToDisplay;
        private bool EnableNext = false;
        private int CurrentIndex
        {
            get
            {
                object o = ViewState["CurrentIndex"];
                if (o != null)
                {
                    return (int)o;
                }
                else
                {
                    return 0;
                }
            }
            set
            {
                ViewState["CurrentIndex"] = value;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Bind Categories list to CategoriesDropDown and set the initial selected value
                List<string> categoriesList = ToDoItemData.GetCategories();
                categoriesList.Add("ALL");
                CategoryDropDown.DataSource = categoriesList;
                CategoryDropDown.DataBind();
                int currentCategoryIndex = ToDoItemData.GetCategories().IndexOf(CategoryFilter);
                CategoryDropDown.SelectedIndex = currentCategoryIndex;
            }
        }

        protected void Page_PreRender(object sender, EventArgs e)
        {
            BindListToDisplay();
            NextButton.Enabled = EnableNext;
            PreviousButton.Enabled = CurrentIndex == 0 ? false : true;
        }

        /// <summary>
        /// Sets the Done property of a ToDoItem to true.
        /// </summary>
        /// <param name="source"></param>
        /// <param name="e"></param>
        protected void TODOs_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            int index = int.Parse(e.CommandArgument.ToString());
            //List<ToDoItem> todos = ToDoItemData.GetToDoItems();
            PruneList();
            ListToDisplay[index].Done = true;
            BindListToDisplay();
        }

        /// <summary>
        /// Prunes the to-do list if necessary and binds it to the TODOs repeater.
        /// </summary>
        private void BindListToDisplay()
        {
            if (ListToDisplay == null)
            {
                PruneList();
            }
            TODOs.DataSource = ListToDisplay;
            TODOs.DataBind();
        }

        /// <summary>
        /// Gets the list of ToDoItems from the data store and applies the
        /// category filter as well as the correct pagination.
        /// </summary>
        private void PruneList()
        {
            ListToDisplay = ToDoItemData.GetToDoItems();

            if (!string.IsNullOrWhiteSpace(CategoryFilter))
            {
                ListToDisplay = ListToDisplay.FindAll(HasCategory);
            }

            int endIndex = NumberOfRecordsToDisplay + CurrentIndex;
            if (endIndex > ListToDisplay.Count)
            {
                ListToDisplay = ListToDisplay.GetRange(CurrentIndex, ListToDisplay.Count - CurrentIndex);
                EnableNext = false;
            }
            else
            {
                ListToDisplay = ListToDisplay.GetRange(CurrentIndex, NumberOfRecordsToDisplay);
                EnableNext = true;
            }
        }

        /// <summary>
        /// Returns true if the ToDoItem's Category matches the ViewState's Category.
        /// </summary>
        /// <param name="item">The ToDoItem to check.</param>
        /// <returns>True if the categories match; false otherwise.</returns>
        private bool HasCategory(ToDoItem item)
        {
            if (CategoryFilter.Equals("ALL") || item.Category.Equals(CategoryFilter))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        protected void PreviousButton_Click(object sender, EventArgs e)
        {
            CurrentIndex -= NumberOfRecordsToDisplay;
        }

        protected void NextButton_Click(object sender, EventArgs e)
        {
            CurrentIndex += NumberOfRecordsToDisplay;
        }

        protected void CategoryDropDown_SelectedIndexChanged(object sender, EventArgs e)
        {
            CategoryFilter = CategoryDropDown.SelectedValue;
            CurrentIndex = 0;
        }
    }
}
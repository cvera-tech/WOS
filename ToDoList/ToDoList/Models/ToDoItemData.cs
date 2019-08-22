using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ToDoList.Data
{
    public class ToDoItemData
    {
        // This is a hack. We are working around not having a database.
        private static List<ToDoItem> Items = new List<ToDoItem>();
        private static List<string> Categories = new List<string>();

        /// <summary>
        /// Returns the list of to-do items.
        /// </summary>
        /// <returns>The list of to-do items.</returns>
        public static List<ToDoItem> GetToDoItems()
        {
            if (Items.Count == 0)
            {
                // Init sample list
                for (int i = 0; i < 12; i++)
                {
                    ToDoItemData.AddItem("personal" + i, "Personal");
                    ToDoItemData.AddItem("work" + i, "Work");
                    ToDoItemData.AddItem("chores" + i, "Chores");
                    ToDoItemData.AddItem("misc" + i, "Misc");
                }
            }
            return Items;
        }

        /// <summary>
        /// Returns a list of Categories recognized by the app. 
        /// Generates default values on first call.
        /// </summary>
        /// <returns>The list of categories.</returns>
        public static List<string> GetCategories()
        {
            if (Categories.Count == 0)
            {
                Categories.Add("Personal");
                Categories.Add("Work");
                Categories.Add("Chores");
                Categories.Add("Misc");
            }
            return Categories;
        }

        /// <summary>
        /// Adds a to-do item to the list with a Category of "Misc".
        /// </summary>
        /// <param name="text">The description of the to-do item.</param>
        public static void AddItem(string text)
        {
            Items.Add(new ToDoItem
            {
                Description = text,
                Category = "Misc",
                Done = false
            });
        }

        /// <summary>
        /// Adds a to-do item to the list.
        /// Also adds an unrecognized category to the Categories list.
        /// </summary>
        /// <param name="text">The description of the to-do item.</param>
        public static void AddItem(string text, string category)
        {
            if (!Categories.Contains(category))
            {
                Categories.Add(category);
            }
            Items.Add(new ToDoItem
            {
                Description = text,
                Category = category,
                Done = false
            });
        }
    }
}
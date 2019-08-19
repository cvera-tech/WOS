using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ToDoList.Models
{
    public class ToDoItemData
    {
        // This is a hack. We are working around
        // not having a database.
        private static List<ToDoItem> Items = new List<ToDoItem>();
        public static List<ToDoItem> GetToDoItems()
        {
            return Items;
        }

        public static void AddItem(string text)
        {
            Items.Add(new ToDoItem
            {
                Description = text,
                Done = false
            }) ;
        }
    }
}
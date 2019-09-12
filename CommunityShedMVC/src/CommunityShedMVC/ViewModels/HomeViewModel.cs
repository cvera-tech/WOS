using CommunityShedMVC.Models;
using System.Collections.Generic;

namespace CommunityShedMVC.ViewModels
{
    public class HomeViewModel
    {
        public List<Item> BorrowedItems { get; set; }
        public List<Item> UserItems { get; set; }
        public List<Community> Communities { get; set; }
    }
}
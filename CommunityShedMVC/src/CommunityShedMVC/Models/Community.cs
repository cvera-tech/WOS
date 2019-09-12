using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CommunityShedMVC.Models
{
    public class Community
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsOpen { get; set; }

        public override string ToString()
        {
            return $"{Id}: {Name} ({(IsOpen ? "Open" : "Closed" )})";
        }
    }
}
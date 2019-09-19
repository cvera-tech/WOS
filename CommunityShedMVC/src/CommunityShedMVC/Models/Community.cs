using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CommunityShedMVC.Models
{
    public class Community
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Display(Name = "Open")]
        public bool IsOpen { get; set; }

        public override string ToString()
        {
            return $"{Id}: {Name} ({(IsOpen ? "Open" : "Closed" )})";
        }
    }
}
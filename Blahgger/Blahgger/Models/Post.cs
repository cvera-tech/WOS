using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Blahgger.Models
{
    public class Post
    {
        public int Id { get; set; }

        public string Text { get; set; }

        [Display(Name = "Created On")]
        public DateTimeOffset CreatedOn { get; set; }

        public int UsersId { get; set; }

        public string Username { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace Blahgger.Models
{
    public class User
    {
        public int UsersId { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        [Display(Name = "Password")]
        public string HashedPassword { get; set; }
    }
}
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InvoiceMaker.Models
{
    public class Client
    {
        public int Id { get; set; }
        [Required, Column("ClientName"), MaxLength(255)]
        public string Name { get; set; }
        [Column("IsActivated")]
        public bool IsActive { get; set; }

        public Client() { }

        public Client(int id)
        {
            Id = id;
        }

        public Client(string name, bool isActive)
        {
            Name = name;
            IsActive = isActive;
        }

        public Client(int id, string name, bool isActive) : this(name, isActive)
        {
            Id = id;
        }

        public void Activate()
        {
            IsActive = true;
        }

        public void Deactivate()
        {
            IsActive = false;
        }
    }
}
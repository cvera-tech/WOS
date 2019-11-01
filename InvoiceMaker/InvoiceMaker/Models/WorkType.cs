using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InvoiceMaker.Models
{
    public class WorkType
    {
        public int Id { get; set; }
        [Required, MaxLength(255)]
        public string Name { get; set; }
        [Required]
        public decimal Rate { get; set; }
        
        public WorkType() { }

        public WorkType(int id)
        {
            Id = id;
        }

        public WorkType(string name, decimal rate)
        {
            Name = name;
            Rate = rate;
        }

        public WorkType(int id, string name, decimal rate) : this(name, rate)
        {
            Id = id;
        }
    }
}
namespace InvoiceMaker.Models
{
    public class WorkType
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public decimal Rate { get; private set; }
        
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
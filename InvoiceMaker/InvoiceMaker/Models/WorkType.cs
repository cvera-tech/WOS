namespace InvoiceMaker.Models
{
    public class WorkType
    {
        public string Name { get; private set; }
        public decimal Rate { get; private set; }
        
        public WorkType(string name, decimal rate)
        {
            Name = name;
            Rate = rate;
        }
    }
}
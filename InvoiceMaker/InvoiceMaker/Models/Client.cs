namespace InvoiceMaker.Models
{
    public class Client
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public bool IsActive { get; private set; }
        public Client() { }

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
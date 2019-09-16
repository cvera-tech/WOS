namespace InvoiceMaker.Models
{
    public class Client
    {
        public string Name { get; private set; }
        public bool IsActive { get; private set; }
        public Client(string name, bool isActive)
        {
            Name = name;
            IsActive = isActive;
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
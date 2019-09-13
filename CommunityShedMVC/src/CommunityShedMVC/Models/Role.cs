namespace CommunityShedMVC.Models
{
    public class Role
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public override bool Equals(object obj)
        {
            Role role = obj as Role;
            if (role == null)
            {
                return false;
            }
            else
            {
                return Id == role.Id && Name == role.Name;
            }
        }
    }
}
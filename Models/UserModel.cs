namespace Java.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }
        public bool IsManager { get; set; } = false;
        public UserModel()
        {
            
        }
        public UserModel( string name, string email, string password, string phone)
        {
            Name = name;
            Email = email;
            Password = password;
            Phone = phone;
        }
        public UserModel(int id, string name, string email, string password, string phone)
        {
            Id = id;
            Name = name;
            Email = email;
            Password = password;
            Phone = phone;
        }
    }
}

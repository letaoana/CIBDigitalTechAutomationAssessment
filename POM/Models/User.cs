namespace POM.PageObjects
{
    public class User
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Customer { get; set; }
        public string Role { get; set; }
        public string Email { get; set; }
        public string CellPhone { get; set; }
        public string Password { get; set; }

        public User(string firstName, string lastName, string username, string customer, string role, string email, string cellPhone)
        {
            FirstName = firstName;
            LastName = lastName;
            Username = username;
            Customer = customer;
            Role = role;
            Email = email;
            CellPhone = cellPhone;
        }

        public User()
        {
        }
    }
}
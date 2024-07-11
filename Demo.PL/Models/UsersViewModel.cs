namespace Demo.PL.Models
{
    public class UsersViewModel
    {
        public string Id { get; set; }

        public string Name { get; set; }
       
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

        public IEnumerable<string> Roles { get; set; }



    }
}

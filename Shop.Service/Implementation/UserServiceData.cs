using Shop.Service.API;

namespace Shop.Service.Implementation
{
    internal class UserServiceData : IUserServiceData
    {
        public UserServiceData(int id, string firstName, string lastName, string address)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Address = address;
        }

        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Address { get; set; }
    }
}

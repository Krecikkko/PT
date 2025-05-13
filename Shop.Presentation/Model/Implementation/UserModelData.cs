using Shop.Presentation.Model.API;

namespace Shop.Presentation.Model.Implementation
{
    internal class UserModelData : IUserModelData
    {
        public int Id
        {
            get; set;
        }

        public string FirstName
        {
            get; set;
        }

        public string LastName
        {
            get; set;
        }

        public string Address
        {
            get; set;
        }

        public UserModelData(int id, string firstName, string lastName, string address)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Address = address;
        }
    }
}

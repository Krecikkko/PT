using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Shop.Presentation.Test")]
namespace Shop.Presentation.ViewModel
{
    internal class VMUser : PropertyChange
    {
        private int _id;
        private string _firstName;
        private string _lastName;
        private string _address;

        public VMUser()
        {

        }

        public VMUser(int id, string firstName, string lastName, string addresS)
        {
            _id = id;
            _firstName = firstName;
            _lastName = lastName;
            _address = addresS;
        }

        public int Id
        {
            get => _id;

            set
            {
                _id = value;
                OnPropertyChanged(nameof(Id));
            }
        }

        public string firstName
        {
            get => _firstName;
            set
            {
                _firstName = value;

                OnPropertyChanged(nameof(firstName));
            }
        }
        public string lastName
        {
            get => _lastName;
            set
            {
                _lastName = value;

                OnPropertyChanged(nameof(lastName));
            }
        }
        public string Address
        {
            get => _address;
            set
            {
                _address = value;

                OnPropertyChanged(nameof(Address));
            }
        }
    }
}

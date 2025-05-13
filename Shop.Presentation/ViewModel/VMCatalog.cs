using System.Runtime.CompilerServices;
using System.Windows.Input;

[assembly: InternalsVisibleTo("Shop.Presentation.Test")]
namespace Shop.Presentation.ViewModel
{
    internal class VMCatalog : PropertyChange
    {
        private int _id;
        private string _name;
        private double _price;
        public ICommand AddCat { get; }
        public ICommand DeleteCat { get; }

        public VMCatalog(int id, string name, double price)
        {
            _id = id;
            _name = name;
            _price = price;
        }

        public VMCatalog() : this(0, "Sample", 0) { }

        public int Id
        {
            get => _id;

            set
            {
                _id = value;
                OnPropertyChanged(nameof(Id));
            }
        }

        public string Name
        {
            get => _name;

            set
            {
                _name = value;
                OnPropertyChanged(nameof(Name));
            }
        }

        public double Price
        {
            get => _price;

            set
            {
                _price = value;
                OnPropertyChanged(nameof(Price));
            }
        }
    }
}

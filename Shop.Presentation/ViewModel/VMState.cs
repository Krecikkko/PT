using Shop.Presentation.Model.API;
using System.Runtime.CompilerServices;
using System.Windows.Input;

[assembly: InternalsVisibleTo("Shop.Presentation.Test")]
namespace Shop.Presentation.ViewModel
{
    internal class VMState : PropertyChange
    {
        private int _id;
        private int _quantity;
        private int _catalogId;
        private readonly IModel _model;
        public ICommand AddState { get; }
        public ICommand DeleteState { get; }

        public VMState()
        {
            _id = 0;
            _quantity = 0;
            _catalogId = 0;
        }

        public VMState(int id, int quantity, int catalogId)
        {
            _id = id;
            _quantity = quantity;
            _catalogId = catalogId;

            AddState = new RelayCommand(e => { _ = Add(); }, a => true);
            DeleteState = new RelayCommand(e => { _ = Delete(); }, a => true);
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

        public int Quantity
        {
            get => _quantity;
            set
            {
                _quantity = value;

                OnPropertyChanged(nameof(Quantity));
            }
        }
        public int CatalogId
        {
            get => _catalogId;
            set
            {
                _catalogId = value;

                OnPropertyChanged(nameof(CatalogId));
            }
        }

        private async Task Add()
        {
            await _model.AddState(Id, Quantity, CatalogId);
        }
        private async Task Delete()
        {
            await _model.RemoveState(Id);
        }
    }
}

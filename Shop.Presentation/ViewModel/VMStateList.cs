using Shop.Presentation.Model.API;
using System.Collections.ObjectModel;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Shop.Presentation.Test")]
namespace Shop.Presentation.ViewModel
{
    internal class VMStateList : PropertyChange
    {
        private int _id;
        private int _quantity;
        private int _catalogId;

        private IModel _iModel;

        private ObservableCollection<VMState> StateVM;

        public VMStateList()
        {
            _iModel = _iModel ?? IModel.CreateNewModel();
            StateVM = new ObservableCollection<VMState>();
        }
        public VMStateList(IModel? model)
        {
            _iModel = model ?? IModel.CreateNewModel();
            StateVM = new ObservableCollection<VMState>();
        }
        public ObservableCollection<VMState> StateView
        {
            get => StateVM;

            set
            {
                StateVM = value;
                OnPropertyChanged(nameof(StateView));
            }
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
    }
}

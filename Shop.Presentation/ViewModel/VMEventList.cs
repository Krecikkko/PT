using Shop.Presentation.Model.API;
using System.Collections.ObjectModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Input;

[assembly: InternalsVisibleTo("Shop.Presentation.Test")]
namespace Shop.Presentation.ViewModel
{
    internal class VMEventList : PropertyChange
    {
        private int _id;
        private int _stateId;
        private int _userId;
        private int _quantityChanged;

        private VMEvent _selectedViewModel;
        private IEventModelData _selectedEvent;
        private IModel _iModel;

        public ICommand SellCommand { get; }
        public ICommand ReturnCommand { get; }
        public ICommand SupplyCommand { get; }
        public ICommand DeleteCommand { get; }
        public ICommand RefreshCommand { get; }

        private ObservableCollection<VMEvent> EventVM;

        public VMEventList()
        {
            _iModel = IModel.CreateNewModel();
            EventVM = new ObservableCollection<VMEvent>();

            SellCommand = new RelayCommand(e => { Sell(); }, a => true);
            ReturnCommand = new RelayCommand(e => { Return(); }, a => true);
            SupplyCommand = new RelayCommand(e => { Supply(); }, a => true);
            DeleteCommand = new RelayCommand(e => { Delete(); }, a => true);
            RefreshCommand = new RelayCommand(e => { GetEvents(); }, a => true);
        }

        public VMEventList(IModel model)
        {
            _iModel = model;
            EventVM = new ObservableCollection<VMEvent>();

            SellCommand = new RelayCommand(e => { Sell(); }, a => true);
            ReturnCommand = new RelayCommand(e => { Return(); }, a => true);
            SupplyCommand = new RelayCommand(e => { Supply(); }, a => true);
            DeleteCommand = new RelayCommand(e => { Delete(); }, a => true);
            RefreshCommand = new RelayCommand(e => { GetEvents(); }, a => true);
        }

        public ObservableCollection<VMEvent> SelectedVM
        {
            get => EventVM;

            set
            {
                EventVM = value;
                OnPropertyChanged(nameof(SelectedVM));
            }
        }
        public IEventModelData SelectedEvent
        {
            get => _selectedEvent;

            set
            {
                _selectedEvent = value;
                OnPropertyChanged(nameof(SelectedEvent));
                _selectedViewModel = new VMEvent(value.Id, value.StateId, value.UserId, value.QuantityChanged);
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
        public int StateId
        {
            get => _stateId;
            set
            {
                _stateId = value;

                OnPropertyChanged(nameof(StateId));
            }
        }
        public int UserID
        {
            get => _userId;
            set
            {
                _userId = value;

                OnPropertyChanged(nameof(UserID));
            }
        }
        public int QuantityChanged
        {
            get => _quantityChanged;
            set
            {
                _quantityChanged = value;

                OnPropertyChanged(nameof(QuantityChanged));
            }
        }

        private VMEvent? EventToPresentation(IEventModelData e)
        {
            return e == null ? null : new VMEvent(e.Id, e.StateId, e.UserId, e.QuantityChanged);
        }
        public void GetEvents()
        {
            EventVM.Clear();

            foreach (var e in _iModel.GetAllEvents())
            {
                EventVM.Add(EventToPresentation(e));
            }

            OnPropertyChanged(nameof(EventVM));
        }

        private async Task Sell()
        {
            await _iModel.SellItem(_selectedViewModel.Id, _selectedViewModel.StateId, _selectedViewModel.UserID, _selectedViewModel.QuantityChanged);
        }

        private async Task Return()
        {
            await _iModel.ReturnItem(_selectedViewModel.Id, _selectedViewModel.StateId, _selectedViewModel.UserID, _selectedViewModel.QuantityChanged);
        }

        private async Task Supply()
        {
            await _iModel.SupplyItem(_selectedViewModel.Id, _selectedViewModel.StateId, _selectedViewModel.UserID, _selectedViewModel.QuantityChanged);
        }

        private async Task Delete()
        {
            await _iModel.RemoveEvent(_selectedViewModel.Id);
        }
    }
}

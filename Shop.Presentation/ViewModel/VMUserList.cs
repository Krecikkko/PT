using Shop.Presentation.Model.API;
using System.Collections.ObjectModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

[assembly: InternalsVisibleTo("Shop.Presentation.Test")]
namespace Shop.Presentation.ViewModel
{
    internal class VMUserList : PropertyChange
    {
        private int _id;
        private string _firstName;
        private string _lastName;
        private string _address;
        private VMUser _selectedViewModel;
        private IUserModelData _selectedUser;
        private IModel _iModel;

        public ICommand AddCommand { get; }
        public ICommand DeleteCommand { get; }
        public ICommand RefreshCommand { get; }

        private ObservableCollection<VMUser> UserVM;

        public VMUserList()
        {
            _iModel = IModel.CreateNewModel();
            UserVM = new ObservableCollection<VMUser>();
            AddCommand = new RelayCommand(e => { Add(); }, a => true);
            DeleteCommand = new RelayCommand(e => { Delete(); }, a => true);
            RefreshCommand = new RelayCommand(e => { GetUsers(); }, a => true);
        }

        public VMUserList(IModel? model)
        {
            _iModel = model ?? IModel.CreateNewModel();
            UserVM = new ObservableCollection<VMUser>();
            AddCommand = new RelayCommand(e => { Add(); }, a => true);
            DeleteCommand = new RelayCommand(e => { Delete(); }, a => true);
            RefreshCommand = new RelayCommand(e => { GetUsers(); }, a => true);
        }
        public ObservableCollection<VMUser> UserView
        {
            get => UserVM;

            set
            {
                UserVM = value;
                OnPropertyChanged(nameof(UserView));
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

        private VMUser? UserToPresentation(IUserModelData u)
        {
            return u == null ? null : new VMUser(u.Id, u.FirstName, u.LastName, u.Address);
        }

        public void GetUsers()
        {
            UserVM.Clear();

            foreach (var u in _iModel.GetAllUsers())
            {
                UserVM.Add(UserToPresentation(u));
            }

            OnPropertyChanged(nameof(UserVM));
        }

        private async Task Add()
        {
            await _iModel.AddUser(_selectedViewModel.Id, _selectedViewModel.firstName, _selectedViewModel.lastName, _selectedViewModel.Address);
        }
        private async Task Delete()
        {
            await _iModel.RemoveUser(_selectedViewModel.Id);
        }
    }
}

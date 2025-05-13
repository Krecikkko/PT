using Shop.Presentation.Model.API;
using Shop.Presentation.Model.Implementation;
using System.Collections.ObjectModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

[assembly: InternalsVisibleTo("Shop.Presentation.Test")]
namespace Shop.Presentation.ViewModel
{
    internal class VMCatalogList : PropertyChange
    {
        private int id;
        private string name;
        private double price;
        private VMCatalog selectedViewModel;
        private ICatalogModelData selectedCatalog;
        private IModel _iModel;

        public ICommand AddCat { get; }
        public ICommand DeleteCat { get; }
        public ICommand Refresh { get; }

        private ObservableCollection<VMCatalog> CatVM;

        public VMCatalogList()
        {
            _iModel = new ModelDefault();
            CatVM = new ObservableCollection<VMCatalog>();
            AddCat = new RelayCommand(e => { Add(); }, a => true);
            DeleteCat = new RelayCommand(e => { Delete(); }, a => true);
            Refresh = new RelayCommand(e => { GetCatalogs(); }, a => true);
        }

        public VMCatalogList(IModel model)
        {
            _iModel = model;
            CatVM = new ObservableCollection<VMCatalog>();
            AddCat = new RelayCommand(e => { Add(); }, a => true);
            DeleteCat = new RelayCommand(e => { Delete(); }, a => true);
            Refresh = new RelayCommand(e => { GetCatalogs(); }, a => true);
        }

        public ObservableCollection<VMCatalog> SelectedVM
        {
            get => CatVM;
            set
            {
                CatVM = value;
                OnPropertyChanged(nameof(SelectedVM));
            }
        }

        public ICatalogModelData SelectedCatalog
        {
            get => selectedCatalog;

            set
            {
                selectedCatalog = value;
                OnPropertyChanged(nameof(SelectedCatalog));
                selectedViewModel = new VMCatalog(value.Id, value.Name, value.Price);
            }
        }

        public int Id
        {
            get => id;

            set
            {
                id = value;
                OnPropertyChanged(nameof(Id));
            }
        }

        public string Name
        {
            get => name;
            set
            {
                name = value;

                OnPropertyChanged(nameof(Name));
            }
        }

        public double Price
        {
            get => price;
            set
            {
                price = value;

                OnPropertyChanged(nameof(Price));
            }
        }

        private VMCatalog? CatalogToPresentation(ICatalogModelData c)
        {
            return c == null ? null : new VMCatalog(c.Id, c.Name, c.Price);
        }

        public void GetCatalogs()
        {
            CatVM.Clear();

            foreach (var c in _iModel.GetAllCatalogs())
            {
                CatVM.Add(CatalogToPresentation(c));
            }

            OnPropertyChanged(nameof(CatVM));
        }

        private async Task Add()
        {
            await _iModel.AddCatalog(selectedViewModel.Id, selectedViewModel.Name, selectedViewModel.Price);
        }

        private async Task Delete()
        {
            await _iModel.RemoveCatalog(selectedViewModel.Id);
        }
    }
}

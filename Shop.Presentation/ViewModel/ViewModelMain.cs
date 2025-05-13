using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;

[assembly: InternalsVisibleTo("Shop.Presentation.Test")]
namespace Shop.Presentation.ViewModel
{
    internal class ViewModelMain : PropertyChange
    {
        private PropertyChange _selectedViewModel;

        public PropertyChange SelectedViewModel
        {
            get => _selectedViewModel;
            set
            {
                if (SetProperty(ref _selectedViewModel, value))
                {
                    OnPropertyChanged(nameof(SelectedViewModel));
                }
            }
        }

        public ICommand UpdateViewCommand { get; }

        public ViewModelMain()
        {
            UpdateViewCommand = new RelayCommand(ChangeView);
            // Set default view:
            SelectedViewModel = new VMCatalogList(); // Or any default
        }

        private void ChangeView(object parameter)
        {
            switch (parameter?.ToString())
            {
                case "CList":
                    SelectedViewModel = new VMCatalogList();
                    break;
                case "UList":
                    SelectedViewModel = new VMUserList();
                    break;
                case "EList":
                    SelectedViewModel = new VMEventList();
                    break;
                case "SList":
                    SelectedViewModel = new VMStateList();
                    break;
            }
        }
    }
}

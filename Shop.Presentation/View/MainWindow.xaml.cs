using System.Windows;
using Shop.Presentation.ViewModel;

namespace Shop.Presentation.View
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            DataContext = new ViewModelMain();
        }
    }
}

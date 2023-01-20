using CustomersMaintenanceSchad.ViewModels;
using System.Windows;

namespace CustomersMaintenanceSchad
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly CustomerViewModel _viewModelInstance;
        public MainWindow()
        {
            InitializeComponent();
            DataContext = _viewModelInstance = App.GetServiceInstance<CustomerViewModel>();
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            await _viewModelInstance.LoadCustomers();
        }
    }
}

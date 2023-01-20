using CustomersMaintenanceSchad.ViewModels;
using System.Windows;

namespace CustomersMaintenanceSchad.Views
{
    /// <summary>
    /// Interaction logic for CustomerFormWindow.xaml
    /// </summary>
    public partial class CustomerFormWindow : Window
    {
        public readonly CustomerFormViewModel ViewModel;
        public CustomerFormWindow()
        {
            InitializeComponent();
            DataContext = ViewModel = App.GetServiceInstance<CustomerFormViewModel>();
            ViewModel.Close = Close;
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            await ViewModel.LoadDependencies();
        }

    }
}

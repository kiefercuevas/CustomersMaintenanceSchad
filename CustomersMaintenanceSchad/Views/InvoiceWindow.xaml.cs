using CustomersMaintenanceSchad.ViewModels;
using System.Windows;

namespace CustomersMaintenanceSchad.Views
{
    /// <summary>
    /// Interaction logic for InvoiceWindow.xaml
    /// </summary>
    public partial class InvoiceWindow : Window
    {
        public readonly InvoiceViewModel ViewModel;
        public InvoiceWindow()
        {
            InitializeComponent();
            DataContext = ViewModel = App.GetServiceInstance<InvoiceViewModel>();
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            await ViewModel.LoadInvoices();
        }

    }
}

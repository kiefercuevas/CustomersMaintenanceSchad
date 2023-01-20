using CustomersMaintenanceSchad.ViewModels;
using System.Windows;

namespace CustomersMaintenanceSchad.Views
{
    /// <summary>
    /// Interaction logic for InvoiceCreationWindow.xaml
    /// </summary>
    public partial class InvoiceCreationWindow : Window
    {
        public readonly InvoiceCreationViewModel ViewModel;
        public InvoiceCreationWindow()
        {
            InitializeComponent();
            DataContext = ViewModel = App.GetServiceInstance<InvoiceCreationViewModel>();

            ViewModel.Close = Close;
        }

    }
}

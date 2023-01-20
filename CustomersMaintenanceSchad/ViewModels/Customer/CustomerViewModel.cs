using CommunityToolkit.Mvvm.Input;
using CustomersMaintenanceSchad.Models;
using CustomersMaintenanceSchad.Services.helpers;
using CustomersMaintenanceSchad.Services.Interfaces;
using CustomersMaintenanceSchad.Views;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CustomersMaintenanceSchad.ViewModels
{
    public class CustomerViewModel
    {
        private readonly ICustomerService _customerService;
        private readonly IMessageService _messageService;

        public ObservableCollection<Customer> Customers { get; set; }

        public ICommand CreateCommand { get; set; }
        public ICommand UpdateCommand { get; set; }
        public ICommand DeleteCommand { get; set; }

        public ICommand SeeInvoicesCommand { get; set; }

        public CustomerViewModel(ICustomerService customerService, IMessageService messageService)
        {
            _customerService = customerService;
            _messageService = messageService;

            Customers = new ObservableCollection<Customer>();

            CreateCommand = new AsyncRelayCommand<Customer>(OpenCustomerForm);
            UpdateCommand = new AsyncRelayCommand<Customer>(OpenCustomerForm);
            DeleteCommand = new AsyncRelayCommand<Customer>(DeleteCustomer);

            SeeInvoicesCommand = new RelayCommand<Customer>(SeeInvoices);
        }

        private void SeeInvoices(Customer customer)
        {
            //A little violation of MVVM to keep navigation simple
            InvoiceWindow invoiceWindow = new InvoiceWindow();
            if (customer != null)
            {
                invoiceWindow.ViewModel.SetCustomer(customer);
            }

            _ = invoiceWindow.ShowDialog();
        }

        private async Task OpenCustomerForm(Customer customer)
        {
            //A little violation of MVVM to keep navigation simple
            CustomerFormWindow customerWindow = new CustomerFormWindow();
            if (customer != null)
            {
                customerWindow.ViewModel.SetCustomer(customer);
            }

            _ = customerWindow.ShowDialog();
            if (customerWindow.ViewModel.HasChanged)
            {
                await LoadCustomers();
            }
        }

        private async Task DeleteCustomer(Customer customer)
        {
            try
            {
                if (_messageService.ShowConfirmationMessage("Desea eliminar este cliente?"))
                {
                    customer.Status = false;

                    _ = await _customerService.Update(customer);
                    _ = Customers.Remove(customer);

                    _messageService.ShowMessage("Se ha eliminado el ciente correctamente");
                }
            }
            catch (Exception)
            {
                _messageService.ShowErrorMessage("Ha ocurrido un error al eliminar al cliente");
            }
        }

        public async Task LoadCustomers()
        {
            try
            {
                Customers.Clear();
                foreach (Customer customer in await _customerService.GetActiveCustomersWithTypes())
                {
                    Customers.Add(customer);
                }
            }
            catch (Exception)
            {
                _messageService.ShowErrorMessage("Ha ocurrido un error al cargar los clientes");
            }
        }

    }

}

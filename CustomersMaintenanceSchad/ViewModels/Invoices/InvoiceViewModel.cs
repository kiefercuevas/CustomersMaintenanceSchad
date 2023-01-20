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
    public class InvoiceViewModel : BaseViewModel
    {
        private Customer _customer;
        private readonly IInvoiceService _invoiceService;
        private readonly IMessageService _messageService;

        public ObservableCollection<Invoice> Invoices { get; set; }

        public ICommand CreateInvoiceCommand { get; set; }
        public ICommand SeeInvoiceDetailCommand { get; set; }


        public InvoiceViewModel(IInvoiceService invoiceService, IMessageService messageService)
        {
            _invoiceService = invoiceService;
            _messageService = messageService;

            Invoices = new ObservableCollection<Invoice>();

            CreateInvoiceCommand = new AsyncRelayCommand(CreateInvoice);
            SeeInvoiceDetailCommand = new AsyncRelayCommand<Invoice>(SeeInvoiceDetail);
        }

        private async Task SeeInvoiceDetail(Invoice invoice)
        {
            //A little violation of MVVM to keep navigation simple
            InvoiceCreationWindow invoiceCreationWindow = new InvoiceCreationWindow();
            invoiceCreationWindow.ViewModel.SetCustomer(_customer);
            await invoiceCreationWindow.ViewModel.SetReadOnlyPage(invoice);

            _ = invoiceCreationWindow.ShowDialog();
        }

        private async Task CreateInvoice()
        {
            //A little violation of MVVM to keep navigation simple
            InvoiceCreationWindow invoiceCreationWindow = new InvoiceCreationWindow();
            invoiceCreationWindow.ViewModel.SetCustomer(_customer);
            _ = invoiceCreationWindow.ShowDialog();

            if (invoiceCreationWindow.ViewModel.HasChanged)
            {
                await LoadInvoices();
            }

        }

        public async Task LoadInvoices()
        {
            try
            {
                Invoices.Clear();
                foreach (Invoice invoice in await _invoiceService.GetCustomerInvoices(_customer.Id))
                {
                    Invoices.Add(invoice);
                }
            }
            catch (Exception)
            {
                _messageService.ShowErrorMessage("Ha ocurrido un error al cargar las facturas del cliente");
            }
        }

        public void SetCustomer(Customer customer)
        {
            _customer = customer;
            Title = $"Facturas del cliente {_customer.CustName}";
        }

    }

}

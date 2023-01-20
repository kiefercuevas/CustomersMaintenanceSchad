using CommunityToolkit.Mvvm.Input;
using CustomersMaintenanceSchad.Models;
using CustomersMaintenanceSchad.Models.DTOS;
using CustomersMaintenanceSchad.Services.helpers;
using CustomersMaintenanceSchad.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CustomersMaintenanceSchad.ViewModels
{
    public class InvoiceCreationViewModel : BaseViewModel
    {
        private Customer _customer;
        private readonly IInvoiceService _invoiceService;
        private readonly IMessageService _messageService;

        public InvoiceDTO InvoiceDTO { get; set; }
        public ObservableCollection<InvoiceDetailDTO> InvoiceDetailDTOs { get; set; }

        private bool isEnabled = true;
        public bool IsEnabled
        {
            get => isEnabled;
            set
            {
                isEnabled = value;
                OnPropertyChanged();
            }
        }

        //To keep windows close simple
        public Action Close;
        public bool HasChanged;

        public ICommand CreateDetailCommand { get; set; }
        public ICommand CreateInvoiceCommand { get; set; }
        public ICommand DeleteDetailCommand { get; set; }

        public InvoiceCreationViewModel(IInvoiceService invoiceService, IMessageService messageService)
        {
            _invoiceService = invoiceService;
            _messageService = messageService;

            InvoiceDTO = new InvoiceDTO();
            InvoiceDetailDTOs = new ObservableCollection<InvoiceDetailDTO>();

            CreateInvoiceCommand = new AsyncRelayCommand(CreateInvoice);
            CreateDetailCommand = new RelayCommand(CreateDetail);
            DeleteDetailCommand = new RelayCommand<InvoiceDetailDTO>(DeleteDetail);
        }

        private async Task CreateInvoice()
        {
            try
            {
                if (HasDetails() == false)
                {
                    _messageService.ShowWarningMessage("No hay detalles para la factura");
                    return;
                }

                if (_messageService.ShowConfirmationMessage("Desea crear esta factura?, tenga en cuenta que los detalles vacíos no serán agregados"))
                {
                    Invoice invoice = InvoiceDTO.GetInvoice();
                    invoice.CustomerId = _customer.Id;

                    invoice.InvoiceDetails = InvoiceDetailDTOs
                        .Where(d => d.IsEmpty == false)
                        .Select(d => d.GetDetail())
                        .ToList();

                    _ = await _invoiceService.Add(invoice);
                    _messageService.ShowMessage("Se ha creado la factura correctamente");

                    HasChanged = true;
                    Close?.Invoke();
                }

            }
            catch (Exception)
            {
                _messageService.ShowErrorMessage("Ha ocurrido un error al crear la factura");
            }
        }


        public async Task SetReadOnlyPage(Invoice invoice)
        {
            InvoiceDTO.Total = invoice.Total;
            InvoiceDTO.TotalItbis = invoice.TotalItbis;
            InvoiceDTO.SubTotal = invoice.SubTotal;

            foreach (InvoiceDetail detail in await _invoiceService.GetInvoiceDetails(invoice.Id))
            {
                InvoiceDetailDTOs.Add(new InvoiceDetailDTO(UpdateTotals)
                {
                    Qty = detail.Qty,
                    Price = detail.Price,
                });
            }

            UpdateTotals();
            IsEnabled = false;
        }

        public void SetCustomer(Customer customer)
        {
            _customer = customer;
        }

        private void CreateDetail()
        {
            InvoiceDetailDTOs.Add(new InvoiceDetailDTO(UpdateTotals));
        }

        private void DeleteDetail(InvoiceDetailDTO detail)
        {
            if (detail.IsEmpty || _messageService.ShowConfirmationMessage("Desea eliminar este detalle?"))
            {
                _ = InvoiceDetailDTOs.Remove(detail);
                UpdateTotals();
            }
        }

        private void UpdateTotals()
        {
            decimal total = 0;
            decimal totalItbis = 0;
            decimal subTotal = 0;

            foreach (InvoiceDetailDTO detail in InvoiceDetailDTOs)
            {
                subTotal += detail.SubTotal;
                totalItbis += detail.TotalItbis;
                total += detail.Total;
            }

            InvoiceDTO.SubTotal = subTotal;
            InvoiceDTO.TotalItbis = totalItbis;
            InvoiceDTO.Total = total;
        }

        private bool HasDetails()
        {
            return InvoiceDetailDTOs.Any(i => i.IsEmpty == false);
        }
    }

}

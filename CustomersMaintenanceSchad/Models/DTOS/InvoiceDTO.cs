using CustomersMaintenanceSchad.ViewModels;

namespace CustomersMaintenanceSchad.Models.DTOS
{
    public class InvoiceDTO : ViewNofityObject
    {
        private decimal totalItbis;
        private decimal subTotal;
        private decimal total;

        public decimal TotalItbis
        {
            get => totalItbis;
            set
            {
                totalItbis = value;
                OnPropertyChanged();
            }
        }

        public decimal SubTotal
        {
            get => subTotal;
            set
            {
                subTotal = value;
                OnPropertyChanged();
            }
        }
        public decimal Total
        {
            get => total;
            set
            {
                total = value;
                OnPropertyChanged();
            }
        }

        public Invoice GetInvoice()
        {
            return new Invoice()
            {
                SubTotal = SubTotal,
                TotalItbis = TotalItbis,
                Total = total
            };
        }

    }

}

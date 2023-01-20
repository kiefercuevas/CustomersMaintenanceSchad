using CustomersMaintenanceSchad.ViewModels;
using System;

namespace CustomersMaintenanceSchad.Models.DTOS
{
    public class InvoiceDetailDTO : ViewNofityObject
    {
        private int qty;
        private decimal price;
        private decimal totalItbis;
        private decimal subTotal;
        private decimal total;

        private readonly Action _updateTotalsAction;
        public InvoiceDetailDTO(Action updateTotalsAction)
        {
            _updateTotalsAction = updateTotalsAction;
        }

        public int Qty
        {
            get => qty;
            set
            {
                qty = value;
                OnPropertyChanged();
                CalculateTotals();
            }
        }

        public decimal Price
        {
            get => price;
            set
            {
                price = value;
                OnPropertyChanged();
                CalculateTotals();
            }
        }

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

        public bool IsEmpty => Qty == 0 && price == 0;

        public InvoiceDetail GetDetail()
        {
            return new InvoiceDetail()
            {
                Qty = qty,
                Price = price,
                SubTotal = SubTotal,
                TotalItbis = TotalItbis,
                Total = Total,
            };
        }

        private void CalculateTotals()
        {
            SubTotal = price * Qty;
            TotalItbis = SubTotal * App.Itbis;
            Total = SubTotal + TotalItbis;

            _updateTotalsAction?.Invoke();
        }

    }

}

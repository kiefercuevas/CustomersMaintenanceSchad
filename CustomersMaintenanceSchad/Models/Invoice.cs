using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace CustomersMaintenanceSchad.Models
{
    [Table("Invoice")]
    public class Invoice
    {
        public int Id { get; set; }
        public decimal TotalItbis { get; set; }
        public decimal SubTotal { get; set; }
        public decimal Total { get; set; }

        public int CustomerId { get; set; }
        public virtual Customer Customer { get; set; }

        public virtual List<InvoiceDetail> InvoiceDetails { get; set; }
    }
}

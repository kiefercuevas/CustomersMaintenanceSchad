using System.ComponentModel.DataAnnotations.Schema;

namespace CustomersMaintenanceSchad.Models
{

    [Table("InvoiceDetail")]
    public class InvoiceDetail
    {
        public int Id { get; set; }
        public int Qty { get; set; }
        public decimal Price { get; set; }
        public decimal TotalItbis { get; set; }
        public decimal SubTotal { get; set; }
        public decimal Total { get; set; }

        public int InvoiceId { get; set; }
        public virtual Invoice Invoice { get; set; }
    }
}

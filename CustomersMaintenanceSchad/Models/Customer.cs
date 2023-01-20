using System.Collections.Generic;

namespace CustomersMaintenanceSchad.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string CustName { get; set; }
        public string Address { get; set; }
        public bool Status { get; set; } = true;

        public int CustomerTypeId { get; set; }
        public virtual CustomerType CustomerType { get; set; }

        public virtual List<Invoice> Invoices { get; set; }
    }

}

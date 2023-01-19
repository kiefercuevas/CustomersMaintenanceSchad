using CustomersMaintenanceSchad.Models;
using Microsoft.EntityFrameworkCore;

namespace CustomersMaintenanceSchad.Data
{
    public class TestInvoiceDbContext : DbContext
    {
        public TestInvoiceDbContext(DbContextOptions<TestInvoiceDbContext> options)
            : base(options)
        {

        }

        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<CustomerType> CustomerTypes { get; set; }
        public virtual DbSet<Invoice> Invoices { get; set; }
        public virtual DbSet<InvoiceDetail> InvoiceDetails { get; set; }
    }
}

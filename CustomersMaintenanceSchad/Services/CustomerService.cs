using CustomersMaintenanceSchad.Data;
using CustomersMaintenanceSchad.Models;
using CustomersMaintenanceSchad.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomersMaintenanceSchad.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly TestInvoiceDbContext _context;
        public CustomerService(TestInvoiceDbContext context)
        {
            _context = context;
        }

        public Task<List<Customer>> GetActiveCustomers()
        {
            return _context.Customers.Where(c => c.Status)
                .ToListAsync();
        }

        public async Task<Customer> Add(Customer customer)
        {
            _ = _context.Customers.Add(customer);
            _ = await _context.SaveChangesAsync();

            return customer;
        }

        public async Task<Customer> Update(Customer customer)
        {
            _ = _context.Customers.Update(customer);
            _ = await _context.SaveChangesAsync();

            return customer;
        }

    }
}

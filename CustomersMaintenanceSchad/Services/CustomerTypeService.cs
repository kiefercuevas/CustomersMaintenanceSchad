using System.Collections.Generic;
using System.Threading.Tasks;
using CustomersMaintenanceSchad.Data;
using CustomersMaintenanceSchad.Models;
using CustomersMaintenanceSchad.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CustomersMaintenanceSchad.Services
{
    public class CustomerTypeService : ICustomerTypeService
    {
        private readonly TestInvoiceDbContext _context;
        public CustomerTypeService(TestInvoiceDbContext context)
        {
            _context = context;
        }

        public Task<List<CustomerType>> GetAll()
        {
            return _context.CustomerTypes.ToListAsync();
        }

    }

}

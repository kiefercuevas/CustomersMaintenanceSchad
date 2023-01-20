using CustomersMaintenanceSchad.Data;
using CustomersMaintenanceSchad.Models;
using CustomersMaintenanceSchad.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomersMaintenanceSchad.Services
{
    public class InvoiceService : IInvoiceService
    {
        private readonly TestInvoiceDbContext _context;
        public InvoiceService(TestInvoiceDbContext context)
        {
            _context = context;
        }

        public Task<List<Invoice>> GetCustomerInvoices(int customerId)
        {
            return _context.Invoices
                .Where(i => i.CustomerId == customerId)
                .ToListAsync();
        }

        public Task<List<InvoiceDetail>> GetInvoiceDetails(int invoiceId)
        {
            return _context.InvoiceDetails
                .Where(i => i.InvoiceId == invoiceId)
                .ToListAsync();
        }

        public async Task<Invoice> Add(Invoice newInvoice)
        {
            //ADDING THE NEW INVOICE 
            _ = _context.Invoices.Add(newInvoice);
            _ = await _context.SaveChangesAsync();

            return newInvoice;
        }

    }

}

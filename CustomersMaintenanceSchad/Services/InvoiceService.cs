using CustomersMaintenanceSchad.Data;
using CustomersMaintenanceSchad.Models;
using CustomersMaintenanceSchad.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
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

        public Task<List<Invoice>> GetICustomerInvoices(int customerId)
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
            IDbContextTransaction transaction = null;
            try
            {
                using (transaction = _context.Database.BeginTransaction())
                {
                    //ADDING THE NEW INVOICE 
                    _ = _context.Invoices.Add(newInvoice);
                    _ = await _context.SaveChangesAsync();

                    //ADDIND THE ID OF THE NEW INVOICE
                    foreach (InvoiceDetail invoiceDetail in newInvoice.InvoiceDetails)
                    {
                        invoiceDetail.InvoiceId = newInvoice.Id;
                        _ = _context.InvoiceDetails.Add(invoiceDetail);
                    }

                    _ = await _context.SaveChangesAsync();
                    await transaction.CommitAsync();
                }
            }
            catch (Exception)
            {
                await transaction.RollbackAsync();
                throw;
            }

            return newInvoice;
        }

    }

}

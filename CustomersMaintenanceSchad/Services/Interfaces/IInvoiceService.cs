using CustomersMaintenanceSchad.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CustomersMaintenanceSchad.Services.Interfaces
{
    public interface IInvoiceService
    {
        Task<Invoice> Add(Invoice newInvoice);
        Task<List<Invoice>> GetICustomerInvoices(int customerId);
        Task<List<InvoiceDetail>> GetInvoiceDetails(int invoiceId);
    }
}
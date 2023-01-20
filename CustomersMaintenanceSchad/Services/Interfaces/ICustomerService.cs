using CustomersMaintenanceSchad.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CustomersMaintenanceSchad.Services.Interfaces
{
    public interface ICustomerService
    {
        Task<List<Customer>> GetActiveCustomersWithTypes();
        Task<Customer> Add(Customer customer);
        Task<Customer> Update(Customer customer);
    }
}
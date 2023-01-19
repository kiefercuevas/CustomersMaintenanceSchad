using CustomersMaintenanceSchad.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CustomersMaintenanceSchad.Services.Interfaces
{
    public interface ICustomerService
    {
        Task<List<Customer>> GetActiveCustomers();
        Task<Customer> Add(Customer customer);
        Task<Customer> Update(Customer customer);
    }
}
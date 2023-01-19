using CustomersMaintenanceSchad.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CustomersMaintenanceSchad.Services.Interfaces
{
    public interface ICustomerTypeService
    {
        Task<List<CustomerType>> GetAll();
    }
}
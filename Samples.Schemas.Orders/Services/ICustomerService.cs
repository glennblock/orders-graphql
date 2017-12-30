using System.Collections.Generic;
using System.Threading.Tasks;

namespace Samples.Schemas.Orders
{
    public interface ICustomerService
    {
        Customer GetCustomerById(int id);
        Task<Customer> GetCustomerByIdAsync(int id);
        Task<IEnumerable<Customer>> GetCustomersAsync();
    }
}
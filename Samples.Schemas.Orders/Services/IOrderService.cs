using System.Collections.Generic;
using System.Threading.Tasks;

namespace Samples.Schemas.Orders
{
    public interface IOrderService
    {
        Task<Order> GetByIdAsync(string id);
        Task<IEnumerable<Order>> GetAsync();
    }
}

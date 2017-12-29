using System.Collections.Generic;
using System.Threading.Tasks;

namespace Samples.Schemas.Orders
{
    public interface IOrdersData
    {
        Task<Order> GetOrderByIdAsync(string id);
        Task<IEnumerable<Order>> GetOrdersAsync();
        Task<Order> CreateOrderAsync(Order order);
    }
}

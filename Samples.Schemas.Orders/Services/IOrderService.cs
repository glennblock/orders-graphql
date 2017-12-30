using System.Collections.Generic;
using System.Threading.Tasks;

namespace Samples.Schemas.Orders
{
    public interface IOrderService
    {
        Task<Order> GetByIdAsync(string id);
        Task<IEnumerable<Order>> GetAsync();
        Task<Order> CreateAsync(Order order);
        Task<Order> StartAsync(string orderId);
        Task<Order> CloseAsync(string orderId);
        Task<Order> CompleteAsync(string orderId);
        Task<Order> CancelAsync(string orderId);
    }
}

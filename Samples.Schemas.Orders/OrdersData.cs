using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Samples.Schemas.Orders
{
    public class OrdersData : IOrdersData
    {
        private IList<Order> _orders;
        private IOrderEvents _events;

        public OrdersData(ICustomerData customerData, IOrderEvents events)
        {
            _events = events;
            _orders = new List<Order>();
            _orders.Add(new Order("Test 1", "Test 1 description", DateTime.Now, customerData.GetCustomerById(1)));
            _orders.Add(new Order("Test 2", "Test 2 description", DateTime.Now.AddHours(1), customerData.GetCustomerById(2)));
            _orders.Add(new Order("Test 3", "Test 3 description", DateTime.Now.AddHours(2), customerData.GetCustomerById(3)));
        }

        public Task<IEnumerable<Order>> GetOrdersAsync()
        {
            return Task.FromResult(_orders.AsEnumerable());
        }

        public Task<Order> GetOrderByIdAsync(string id)
        {
            return Task.FromResult(_orders.Single(o => Equals(o.Id, id)));
        }

        public Task<Order> CreateOrderAsync(Order order)
        {
            _orders.Add(order);

            var orderEvent = new OrderEvent(order.Id, order.Name, OrderStatuses.CREATED, order.Created);
            _events.AddEvent(orderEvent);
            return Task.FromResult(order);
        }
    }
}

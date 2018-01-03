using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Samples.Schemas.Orders
{
    public class OrderService : IOrderService
    {
        private IList<Order> _orders;
        private IOrderEventService _events;

        public OrderService(ICustomerService customerData, IOrderEventService events)
        {
            _events = events;
            _orders = new List<Order>();
            _orders.Add(new Order("Test 1", "Test 1 description", DateTime.Now, 1, "FAEBD971-CBA5-4CED-8AD5-CC0B8D4B7827"));
            _orders.Add(new Order("Test 2", "Test 2 description", DateTime.Now.AddHours(1), 2, "F43A4F9D-7AE9-4A19-93D9-2018387D5378"));
            _orders.Add(new Order("Test 3", "Test 3 description", DateTime.Now.AddHours(2), 3, "2D542571-EF99-4786-AEB5-C997D82E57C7"));
        }

        public Task<IEnumerable<Order>> GetAsync()
        {
            return Task.FromResult(_orders.AsEnumerable());
        }

        public Task<Order> GetByIdAsync(string id)
        {
            return Task.FromResult(_orders.Single(o => Equals(o.Id, id)));
        }

        private Order GetById(string id)
        {
            var order = _orders.SingleOrDefault(o => Equals(o.Id, id));
            if (order == null)
            {
                throw new ArgumentException(string.Format("Order ID '{0}' is invalid", id));
            }
            return order;
        }

        public Task<Order> CreateAsync(Order order)
        {
            _orders.Add(order);
            var orderEvent = new OrderEvent(order.Id, order.Name, OrderStatuses.CREATED, order.Created);
            _events.AddEvent(orderEvent);
            return Task.FromResult(order);
        }

        public Task<Order> StartAsync(string orderId)
        {
            var order = GetById(orderId);
            order.Start();
            var orderEvent = new OrderEvent(order.Id, order.Name, OrderStatuses.PROCESSING, DateTime.Now);
            _events.AddEvent(orderEvent);
            return Task.FromResult(order);
        }

        public Task<Order> CompleteAsync(string orderId)
        {
            var order = GetById(orderId);
            order.Complete();
            var orderEvent = new OrderEvent(order.Id, order.Name, OrderStatuses.COMPLETED, DateTime.Now);
            _events.AddEvent(orderEvent);
            return Task.FromResult(order);
        }

        public Task<Order> CloseAsync(string orderId)
        {
            var order = GetById(orderId);
            order.Close();
            var orderEvent = new OrderEvent(order.Id, order.Name, OrderStatuses.CLOSED, DateTime.Now);
            _events.AddEvent(orderEvent);
            return Task.FromResult(order);
        }

        public Task<Order> CancelAsync(string orderId)
        {
            var order = GetById(orderId);
            order.Complete();
            var orderEvent = new OrderEvent(order.Id, order.Name, OrderStatuses.CANCELLED, DateTime.Now);
            _events.AddEvent(orderEvent);
            return Task.FromResult(order);
        }

    }
}

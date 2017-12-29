using System;

namespace Samples.Schemas.Orders
{
    public class OrderEvent
    {
        public OrderEvent(string orderId, string orderName, OrderStatuses status, DateTime timestamp)
        {
            Id = Guid.NewGuid().ToString();
            OrderId = orderId;
            OrderName = orderName;
            Status = status;
            Timestamp = timestamp;
        }

        public string Id { get;  private set; }

        public string OrderName { get; set; }

        public string OrderId { get; set; }

        public OrderStatuses Status { get; set; }

        public DateTime Timestamp { get; private set; }
    }
}



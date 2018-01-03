using System;
using System.Linq;
using GraphQL;

namespace Samples.Schemas.Orders
{
    public class Order
    {
        public Order(string name, string description, DateTime created, int customerId, string id = null)
        {
            if (id == null)
                id = Guid.NewGuid().ToString();

            Id = id;
            Name = name;
            Description = description;
            Created = created;
            CustomerId = customerId;
            Status = OrderStatuses.CREATED;
        }

        public string Id { get; private set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime Created { get; private set; }

        public OrderStatuses Status { get; private set; }

        public int CustomerId { get; private set; }

        public void Close()
        {
            Status = OrderStatuses.CLOSED;
        }

        public void Start()
        {
            Status = OrderStatuses.PROCESSING;
        }

        public void Cancel()
        {
            Status = OrderStatuses.CANCELLED;
        }

        public void Complete()
        {
            Status = OrderStatuses.COMPLETED;
        }

    }
}

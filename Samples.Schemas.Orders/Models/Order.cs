using System;
using System.Linq;
using GraphQL;

namespace Samples.Schemas.Orders
{
    public class Order
    {
        public Order(string name, string description, DateTime created, Customer customer) 
        {
            Id = Guid.NewGuid().ToString();
            Name = name;
            Description = description;
            Created = created;
            Customer = customer;
        }

        public string Id { get; private set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime Created { get; private set; }

        public Customer Customer { get; set; }

        public int CustomerID { get; set; }
    }
}

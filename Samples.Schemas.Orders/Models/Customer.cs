using System;
using System.Collections.Generic;
using System.Text;

namespace Samples.Schemas.Orders
{
    public class Customer
    {
        public Customer(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public int Id { get; private set; }

        public string Name { get; set; }
    }
}

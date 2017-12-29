using System;

namespace Samples.Schemas.Orders
{
    public class OrderCreateInput
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int CustomerId { get; set; }
        public DateTime Created { get; set; }
    }

}

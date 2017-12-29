using GraphQL.Types;

namespace Samples.Schemas.Orders
{
    public class OrderStatusesEnum : EnumerationGraphType
    {
        public OrderStatusesEnum()
        {
            Name = "OrderStatus";
            Description = "Status of the order.";
            AddValue("CREATED", "Order was created", 1);
            AddValue("PROCESSING", "Order is being processed", 2);
            AddValue("COMPLETED", "Order has completed processing", 3);
            AddValue("CANCELLED", "Order was cancelled", 4);
            AddValue("CLOSED", "Order was closed", 5);
        }
    }
}



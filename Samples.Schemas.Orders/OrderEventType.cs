using GraphQL.Types;

namespace Samples.Schemas.Orders
{
    public class OrderEventType : ObjectGraphType<OrderEvent>
    {
        public OrderEventType()
        {
            Field(e => e.Id);
            Field(e => e.OrderName);
            Field(e => e.OrderId);
            Field<ListGraphType<OrderStatusesEnum>>("status", "Status of the order.");
            Field(e => e.Timestamp);
        }
    }
}



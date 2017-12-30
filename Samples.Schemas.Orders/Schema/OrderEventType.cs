using GraphQL.Types;

namespace Samples.Schemas.Orders
{
    public class OrderEventType : ObjectGraphType<OrderEvent>
    {
        public OrderEventType()
        {
            Field(e => e.Id)
                .Description("Event Id");
            Field(e => e.OrderName)
                .Description("Order Name");
            Field(e => e.OrderId)
                .Description("Order Id");
            Field<OrderStatusesEnum>("status", "Status for the order");
            Field(e => e.Timestamp)
                .Description("When the event occured");
        }
    }
}



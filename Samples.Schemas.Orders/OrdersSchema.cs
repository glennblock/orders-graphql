using GraphQL.Types;

namespace Samples.Schemas.Orders
{
    public class OrdersSchema : Schema
    {
        public OrdersSchema(IOrdersData orders, ICustomerData customers, IOrderEvents events)
        {
            Query = new OrdersQuery(orders, customers, events);
            Mutation = new OrdersMutation(orders, customers);
            Subscription = new OrderEventSubscriptions(events);
        }
    }
}

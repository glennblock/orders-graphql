using GraphQL.Types;

namespace Samples.Schemas.Orders
{
    public class OrdersSchema : Schema
    {
        public OrdersSchema(OrdersQuery query, OrdersMutation mutation, OrdersSubscription subscription)
        {
            Query = query;
            Mutation = mutation;
            Subscription = subscription;
        }
    }
}

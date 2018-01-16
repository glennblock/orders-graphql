using GraphQL;
using GraphQL.Types;

namespace Samples.Schemas.Orders
{
    public class OrdersSchema : Schema
    {
        public OrdersSchema(OrdersQuery query, OrdersMutation mutation, OrdersSubscription subscription, IDependencyResolver resolver)
        {
            Query = query;
            Mutation = mutation;
            Subscription = subscription;
            DependencyResolver = resolver;
        }
    }
}

using GraphQL.Types;

namespace Samples.Schemas.Orders
{
    public class OrderType : ObjectGraphType<Order>
    {
        public OrderType()
        {
            Field(o => o.Id);
            Field(o => o.Name);
            Field(o => o.Description);
            Field<CustomerType>("customer",
                resolve: context => context.Source.Customer);
            Field<OrderStatusesEnum>("status",
                resolve: context => context.Source.Status);
            Field(o => o.Created);

        }
    }
}

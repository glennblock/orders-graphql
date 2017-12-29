using GraphQL.Types;
using System.Linq;

namespace Samples.Schemas.Orders
{
    public class OrdersQuery : ObjectGraphType<object>
    {
        public OrdersQuery(IOrderService orders, ICustomerService customers, IOrderEventService events)
        {
            Name = "Query";
            Field<ListGraphType<OrderType>>(
                "orders",
                resolve: context => orders.GetOrdersAsync()
            );
            Field<OrderType>(
                "order",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "id", Description = "id of the order" }
                ),
                resolve: context => orders.GetOrderByIdAsync(context.GetArgument<string>("id"))
            );
            Field<ListGraphType<CustomerType>>(
                "customers",
                resolve: context => customers.GetCustomersAsync()
            );
            Field<CustomerType>(
                "customer",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<DecimalGraphType>> { Name = "id", Description = "id of the order" }
                ),
                resolve: context => customers.GetCustomerByIdAsync(context.GetArgument<int>("id"))
            );
        }
    }



}

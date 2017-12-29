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
                resolve: context => orders.GetAsync()
            );
            Field<OrderType>(
                "order",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "id" }
                ),
                resolve: context => orders.GetByIdAsync(context.GetArgument<string>("id"))
            );
            Field<ListGraphType<CustomerType>>(
                "customers",
                resolve: context => customers.GetCustomersAsync()
            );
            Field<CustomerType>(
                "customer",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<DecimalGraphType>> { Name = "id" }
                ),
                resolve: context => customers.GetCustomerByIdAsync(context.GetArgument<int>("id"))
            );
        }
    }



}

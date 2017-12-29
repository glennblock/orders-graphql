using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace Samples.Schemas.Orders
{
    public class OrdersMutation : ObjectGraphType<object>
    {
        public OrdersMutation(IOrdersData orders, ICustomerData customers)
        {
            Name = "Mutation";

            Field<OrderType>(
                "createOrder",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<OrderInputType>> { Name = "order" }
                ),
                resolve: context =>
                {
                    var orderInput = context.GetArgument<OrderInput>("order");
                    var customer = customers.GetCustomerById(orderInput.CustomerId);
                    var order = new Order(orderInput.Name, orderInput.Description, orderInput.Created, customer);
                    return orders.CreateOrderAsync(order);
                }
            );
        }
    }
}

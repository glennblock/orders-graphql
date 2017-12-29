using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace Samples.Schemas.Orders
{
    public class OrdersMutation : ObjectGraphType<object>
    {
        public OrdersMutation(IOrderService orders, ICustomerService customers)
        {
            Name = "Mutation";

            Field<OrderType>(
                "createOrder",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<OrderCreateInputType>> { Name = "order" }
                ),
                resolve: context =>
                {
                    var orderInput = context.GetArgument<OrderCreateInput>("order");
                    var customer = customers.GetCustomerById(orderInput.CustomerId);
                    var order = new Order(orderInput.Name, orderInput.Description, orderInput.Created, customer);
                    return orders.CreateAsync(order);
                },
                description: "Create a new order"
            );

            Field<OrderType>(
                "startOrder",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<OrderActionInputType>> { Name = "orderId" }
                ),
                resolve: context =>
                {
                    var orderInput = context.GetArgument<OrderActionInput>("orderId");
                    return orders.StartAsync(orderInput.OrderId);
                },
                description: "Start an order"
            );

            Field<OrderType>(
                "closeOrder",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<OrderActionInputType>> { Name = "orderId" }
                ),
                resolve: context =>
                {
                    var orderInput = context.GetArgument<OrderActionInput>("orderId");
                    return orders.CloseAsync(orderInput.OrderId);
                },
                description: "Close an order"
            );

            Field<OrderType>(
                "completeOrder",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<OrderActionInputType>> { Name = "orderId" }
                ),
                resolve: context =>
                {
                    var orderInput = context.GetArgument<OrderActionInput>("orderId");
                    return orders.CompleteAsync(orderInput.OrderId);
                },
                description: "Complete an order"
            );

            Field<OrderType>(
                "cancelOrder",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<OrderActionInputType>> { Name = "orderId" }
                ),
                resolve: context =>
                {
                    var orderInput = context.GetArgument<OrderActionInput>("orderId");
                    return orders.CancelAsync(orderInput.OrderId);
                },
                description: "Cancel an order"
            );


        }
    }
}

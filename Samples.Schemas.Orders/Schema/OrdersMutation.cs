using GraphQL;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

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
                    var order = new Order(orderInput.Name, orderInput.Description, orderInput.Created, orderInput.CustomerId);
                    return orders.CreateAsync(order);
                },
                description: "Create a new order"
            );

            FieldAsync<OrderType>(
                "startOrder",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "orderId" }
                ),
                resolve: async context =>
                {
                    var orderId = context.GetArgument<String>("orderId");
                    return await context.TryAsyncResolve(async c => await orders.StartAsync(orderId));
                },
                description: "Start an order"
            );

            FieldAsync<OrderType>(
                "closeOrder",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "orderId" }
                ),
                resolve: context =>
                {
                    var orderId = context.GetArgument<String>("orderId");
                    return context.TryAsyncResolve(async c => await orders.CloseAsync(orderId));
                },
                description: "Close an order"
            );

            FieldAsync<OrderType>(
                "completeOrder",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "orderId" }
                ),
                resolve: async context =>
                {
                    var orderId = context.GetArgument<String>("orderId");
                    return await context.TryAsyncResolve(async c => await orders.CompleteAsync(orderId));
                },
                description: "Complete an order"
            );

            FieldAsync<OrderType>(
                "cancelOrder",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "orderId" }
                ),
                resolve: async context =>
                {
                    var orderId = context.GetArgument<String>("orderId");
                    return await context.TryAsyncResolve(async c => await orders.CancelAsync(orderId));
                },
                description: "Cancel an order"
            );


        }
    }
}

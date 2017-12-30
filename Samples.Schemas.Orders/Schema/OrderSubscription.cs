using System;
using System.Linq;
using System.Reactive.Linq;
using GraphQL.Resolvers;
using GraphQL.Subscription;
using GraphQL.Types;
using System.Collections.Generic;

namespace Samples.Schemas.Orders
{
    public class OrderSubscription : ObjectGraphType<object>
    {
        private readonly IOrderEventService _events;

        public OrderSubscription(IOrderEventService events) 
        {
            Name = "Subscription";
            _events = events;
            AddField(new EventStreamFieldType
            {
                Name = "orderEvent",
                Arguments = new QueryArguments(
                    new QueryArgument<ListGraphType<OrderStatusesEnum>> { Name = "statuses" }
                ),
                Type = typeof(OrderEventType),
                Resolver = new FuncFieldResolver<OrderEvent>(ResolveEvent),
                Subscriber = new EventStreamResolver<OrderEvent>(Subscribe)
            });
        }

        private OrderEvent ResolveEvent(ResolveFieldContext context)
        {
            var orderEvent = context.Source as OrderEvent;
            return orderEvent;
        }

        private IObservable<OrderEvent> Subscribe(ResolveEventStreamContext context)
        {
            var statusList = context.GetArgument<IList<OrderStatuses>>("statuses", new List<OrderStatuses>());

            if (statusList.Count > 0)
            {
                OrderStatuses statuses = 0;

                foreach(var status in statusList)
                {
                    statuses = statuses | status;
                }

                return _events.EventStream().Where(e => (e.Status & statuses) == e.Status);
            }
            else
            {
                return _events.EventStream();
            }
        }
    }
}



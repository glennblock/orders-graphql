using System;
using System.Reactive.Linq;
using GraphQL.Resolvers;
using GraphQL.Subscription;
using GraphQL.Types;

namespace Samples.Schemas.Orders
{
    public class OrderEventSubscriptions : ObjectGraphType<object>
    {
        private readonly IOrderEvents _events;

        public OrderEventSubscriptions(IOrderEvents events) 
        {
            _events = events;
            AddField(new EventStreamFieldType
            {
                Name = "orderEvent",
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
            return _events.EventStream();
        }
    }
}



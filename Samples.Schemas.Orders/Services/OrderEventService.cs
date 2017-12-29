using System;
using System.Collections.Concurrent;
using System.Reactive.Linq;
using System.Reactive.Subjects;

namespace Samples.Schemas.Orders
{
    public class OrderEventService : IOrderEventService
    {
        private readonly ISubject<OrderEvent> _eventStream = new ReplaySubject<OrderEvent>(1);

        public OrderEventService()
        {
            AllEvents = new ConcurrentStack<OrderEvent>();
        }

        public ConcurrentStack<OrderEvent> AllEvents { get; }

        public OrderEvent AddEvent(OrderEvent orderEvent) {
            AllEvents.Push(orderEvent);
            _eventStream.OnNext(orderEvent);
            return orderEvent;
        }

        public IObservable<OrderEvent> EventStream()
        {
            return _eventStream.AsObservable();
        }

        public void AddError(Exception exception)
        {
            _eventStream.OnError(exception);
        }
    }



}



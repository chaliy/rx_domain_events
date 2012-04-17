namespace TryComplexRx.Abstractions
{
    using System;
    using System.Reactive.Subjects;

    public class EntityInContext
    {
        readonly Subject<dynamic> events = new Subject<dynamic>();

        public IObservable<dynamic> Events { get { return events; } }

        protected void SubmitEvent(dynamic @event)
        {
            events.OnNext(@event);
        }
    }
}

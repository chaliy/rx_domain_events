namespace TryComplexRx.Abstractions
{
    public class EntityInContext : IInContext
    {
        public string Context { get; protected set; }

        protected void SubmitEvent(dynamic @event)
        {
            @event.Context = Context;
            Env.Events.OnNext(@event);
        }
    }
}

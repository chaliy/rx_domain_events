namespace TryComplexRx.Abstractions
{
    public abstract class EventInContext : IInContext
    {
        public string Context { get; set; }
    }
}

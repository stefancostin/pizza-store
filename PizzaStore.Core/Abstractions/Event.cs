namespace PizzaStore.Core.Abstractions;

public interface Event
{
    public Guid AggregateId { get; }
}

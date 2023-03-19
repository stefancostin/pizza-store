namespace PizzaStore.Core.Abstractions;

public interface Command
{
    public Guid AggregateId { get; }
}

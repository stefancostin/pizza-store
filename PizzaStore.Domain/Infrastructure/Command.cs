namespace PizzaStore.Domain.Infrastructure;

public interface Command
{
    public Guid AggregateId { get; }
}

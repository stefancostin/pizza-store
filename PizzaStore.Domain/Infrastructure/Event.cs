namespace PizzaStore.Domain.Infrastructure;

public interface Event
{
    public Guid AggregateId { get; }
}

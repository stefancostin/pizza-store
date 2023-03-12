namespace PizzaStore.Domain.Infrastructure;

public interface Event
{
}

public record EventMessage(Guid AggregateId, Event Event);

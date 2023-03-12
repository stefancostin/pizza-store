namespace PizzaStore.Domain.Infrastructure;

public abstract class Aggregate
{
    public abstract void Apply(Event @event);
    public abstract IEnumerable<Event> Handle(Command command);
}

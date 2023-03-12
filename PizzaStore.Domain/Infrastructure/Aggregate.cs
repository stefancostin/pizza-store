namespace PizzaStore.Domain.Infrastructure;

internal abstract class Aggregate
{
    public abstract void Apply(Event @event);
    public abstract IEnumerable<Event> Handle(Command command);
}

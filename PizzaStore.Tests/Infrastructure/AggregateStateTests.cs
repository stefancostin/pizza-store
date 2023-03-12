using PizzaStore.Domain.Infrastructure;

namespace PizzaStore.Tests.Infrastructure;

public class AggregateStateTests<TAggregate>
    where TAggregate : Aggregate, new()
{
    private TAggregate _aggregate;
    private readonly List<Event> _previousEvents = new List<Event>();

    protected void Given(params Event[] events)
    {
        _aggregate = new TAggregate();

        _previousEvents.Clear();
        _previousEvents.AddRange(events);
    }

    protected void When(Command command)
    {
        foreach (var previousEvent in _previousEvents)
        {
            _aggregate.Apply(previousEvent);
        }

        var resultingEvents = _aggregate.Handle(command);

        foreach (var resultingEvent in resultingEvents)
        {
            _aggregate.Apply(resultingEvent);
        }
    }

    protected void Then(Action<TAggregate> executeAssertions)
    {
        executeAssertions(_aggregate);
    }
}

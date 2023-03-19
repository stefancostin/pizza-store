using PizzaStore.Core.Abstractions;

namespace PizzaStore.Tests.Infrastructure;

public class AggregateStateTests<TAggregate>
    where TAggregate : Aggregate, new()
{
    private TAggregate _aggregate;

    protected void Given(params Event[] events)
    {
        _aggregate = new TAggregate();

        foreach (var @event in events)
        {
            _aggregate.Apply(@event);
        }
    }

    protected void When(Command command)
    {
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

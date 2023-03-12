using FluentAssertions;
using PizzaStore.Domain;
using PizzaStore.Domain.Infrastructure;

namespace PizzaStore.Tests.Infrastructure;

/// <summary>
/// Tests the integration between the command router, handler and aggregate.
/// </summary>
public class EventPipelineTests
{
    private readonly List<Event> _previousEvents = new List<Event>();
    private readonly List<Event> _newEvents = new List<Event>();

    protected void Given(params Event[] events)
    {
        _previousEvents.Clear();
        _previousEvents.AddRange(events);
    }

    protected void When(Command command)
    {
        var router = new CommandRouter(_ => _previousEvents, msg => _newEvents.Add(msg.Event));
        router.HandleCommand(command);
    }

    protected void Then(params Event[] expectedEvents)
    {
        _newEvents.ToArray().Should().Equal(expectedEvents);
    }

    protected void ThenCompareHistory(params Event[] expectedEvents)
    {
        _previousEvents.ToArray().Should().Equal(expectedEvents);
    }
}

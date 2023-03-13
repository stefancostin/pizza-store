using FluentAssertions;
using PizzaStore.Domain;
using PizzaStore.Domain.Infrastructure;
using PizzaStore.Domain.Stores;

namespace PizzaStore.Tests.Infrastructure;

/// <summary>
/// Tests the integration between the command router, handler and aggregate.
/// </summary>
public class EventPipelineTests
{
    private IEventStore _eventStore;
    private List<Event> _allEvents;
    private List<Event> _newEvents;
    private List<Event> _previousEvents;

    protected void Given(params Event[] events)
    {
        _eventStore = new LocalEventStore();

        foreach (var @event in events)
        {
            _eventStore.Publish(@event);
        }

        _previousEvents = events.ToList();
    }

    protected void When(Command command)
    {
        var router = new CommandRouter(_eventStore);
        router.HandleCommand(command);

        _allEvents = _eventStore.GetEvents(command.AggregateId).ToList();
        _newEvents = _allEvents.Except(_previousEvents).ToList();
    }

    protected void Then(params Event[] expectedEvents)
    {
        _newEvents.Should().Equal(expectedEvents);
    }

    protected void ThenAll(params Event[] expectedEvents)
    {
        _allEvents.Should().Equal(expectedEvents);
    }
}

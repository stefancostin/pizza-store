using FluentAssertions;
using PizzaStore.Domain;
using PizzaStore.Domain.Infrastructure;

namespace PizzaStore.Tests.Infrastructure;

public class TestInfrastructure
{
    private readonly List<Event> _events = new List<Event>();
    private readonly List<Event> _newEvents = new List<Event>();

    protected void Given(params Event[] events)
    {
        _events.Clear();
        _events.AddRange(events);
    }

    protected void When(Command command)
    {
        var router = new CommandRouter(_ => _events, msg => _newEvents.Add(msg.Event));
        router.HandleCommand(command);
    }

    protected void Then(params Event[] expectedEvents)
    {
        _newEvents.ToArray().Should().Equal(expectedEvents);
    }
}

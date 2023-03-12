using PizzaStore.Domain.Infrastructure;

namespace PizzaStore.Domain.CommandHandlers;

internal class CommandHandler<TCommand, TAggregate>
    where TCommand : Command
    where TAggregate : Aggregate, new()
{
    protected readonly Func<Guid, IEnumerable<Event>> _eventStream;
    protected readonly Action<EventMessage> _publishEvent;

    protected CommandHandler(
        Func<Guid, IEnumerable<Event>> eventStream,
        Action<EventMessage> publishEvent)
    {
        _eventStream = eventStream;
        _publishEvent = publishEvent;
    }

    public virtual void Handle(TCommand command)
    {
        var previousEvents = _eventStream(command.AggregateId);

        var aggregate = new TAggregate();

        foreach (var previousEvent in previousEvents)
        {
            aggregate.Apply(previousEvent);
        }

        var resultingEvents = aggregate.Handle(command);

        foreach (var resultingEvent in resultingEvents)
        {
            _publishEvent(new EventMessage(command.AggregateId, resultingEvent));
        }
    }
}

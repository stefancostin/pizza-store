﻿using PizzaStore.Core.Abstractions;
using PizzaStore.Core.Infrastructure.EventStores;

namespace PizzaStore.Core.Infrastructure;

internal class CommandHandler<TCommand, TAggregate>
    where TCommand : Command
    where TAggregate : Aggregate, new()
{
    protected readonly IEventStore _eventStore;

    protected CommandHandler(IEventStore eventStore)
    {
        _eventStore = eventStore;
    }

    public virtual void Handle(TCommand command)
    {
        var previousEvents = _eventStore.GetEvents(command.AggregateId);

        var aggregate = new TAggregate();

        foreach (var previousEvent in previousEvents)
        {
            aggregate.Apply(previousEvent);
        }

        var resultingEvents = aggregate.Handle(command);

        foreach (var resultingEvent in resultingEvents)
        {
            _eventStore.Publish(resultingEvent);
        }
    }
}

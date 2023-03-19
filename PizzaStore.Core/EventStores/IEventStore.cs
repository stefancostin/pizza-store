﻿using PizzaStore.Core.Abstractions;

namespace PizzaStore.Core.EventStores;

public interface IEventStore
{
    IEnumerable<Event> Remove(Guid aggregateId, Func<Event, bool> predicate);
    IEnumerable<Event> GetEvents(Guid aggregateId);
    void Publish(Event @event);
}

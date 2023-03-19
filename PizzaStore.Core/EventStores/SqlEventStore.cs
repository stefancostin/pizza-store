﻿using PizzaStore.Core.Abstractions;
using PizzaStore.Core.Infrastructure;

namespace PizzaStore.Core.EventStores;

public class SqlEventStore : IEventStore
{
    private readonly EventContext _database;

    public SqlEventStore(EventContext database)
    {
        _database = database;
    }

    public IEnumerable<Event> GetEvents(Guid aggregateId)
    {
        var events = _database.Events
            .Where(e => e.AggregateId == aggregateId)
            .OrderBy(e => e.Id)
            .ToList();

        return events.Select(e => e.Event);
    }

    public void Publish(Event @event)
    {
        var persistedEvent = new PersistedEvent
        {
            AggregateId = @event.AggregateId,
            Timestamp = DateTime.UtcNow,
            Event = @event
        };

        _database.Events.Add(persistedEvent);
        _database.SaveChanges();
    }

    public IEnumerable<Event> Remove(Guid aggregateId, Func<Event, bool> predicate)
    {
        var events = _database.Events
            .Where(e => e.AggregateId == aggregateId && predicate(e.Event))
            .OrderBy(e => e.Id)
            .ToList();

        if (events.Any())
        {
            _database.Events.RemoveRange(events);
            _database.SaveChanges();
        }

        return events.Select(e => e.Event).ToList();
    }
}

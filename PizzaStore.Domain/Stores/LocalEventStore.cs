﻿using PizzaStore.Domain.Infrastructure;

namespace PizzaStore.Domain.Stores;

public interface IEventStore
{
    IEnumerable<Event> Remove(Guid aggregateId, Func<Event, bool> archivePredicate);
    IEnumerable<Event> GetEvents(Guid aggregateId);
    void Publish(Event @event);
}

public class LocalEventStore : IEventStore
{
    private readonly Dictionary<Guid, List<Event>> _persistedEvents;

    public LocalEventStore()
    {
        _persistedEvents = new Dictionary<Guid, List<Event>>();
    }

    public IEnumerable<Event> GetEvents(Guid aggregateId)
    {
        if (_persistedEvents.TryGetValue(aggregateId, out List<Event> events))
        {
            return events;
        }

        return Enumerable.Empty<Event>();
    }

    public void Publish(Event @event)
    {
        if (_persistedEvents.TryGetValue(@event.AggregateId, out List<Event> events))
        {
            events.Add(@event);
        }
        else
        {
            _persistedEvents.Add(@event.AggregateId, new List<Event> { @event });
        }
    }

    public IEnumerable<Event> Remove(Guid aggregateId, Func<Event, bool> predicate)
    {
        if (_persistedEvents.TryGetValue(aggregateId, out List<Event> persistedEvents))
        {
            var eventsToArchive = persistedEvents.Where(predicate).ToList();

            if (eventsToArchive.Any())
            {
                _persistedEvents[aggregateId] = persistedEvents.Where(e => !predicate(e)).ToList();

                return eventsToArchive;
            }
        }

        return Enumerable.Empty<Event>();
    }
}

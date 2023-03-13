using PizzaStore.Domain.Infrastructure;

namespace PizzaStore.Domain.Stores;

public interface IEventStore
{
    void Archive(Guid aggregateId, Func<Event, bool> archivePredicate);
    IEnumerable<Event> GetEvents(Guid aggregateId);
    void Publish(Event @event);
}

public class LocalEventStore : IEventStore
{
    private readonly Dictionary<Guid, List<Event>> _archivedEvents;
    private readonly Dictionary<Guid, List<Event>> _persistedEvents;

    public LocalEventStore()
    {
        _archivedEvents = new Dictionary<Guid, List<Event>>();
        _persistedEvents = new Dictionary<Guid, List<Event>>();
    }

    public void Archive(Guid aggregateId, Func<Event, bool> archivePredicate)
    {
        if (_persistedEvents.TryGetValue(aggregateId, out List<Event> persistedEvents))
        {
            var eventsToArchive = persistedEvents.Where(archivePredicate).ToList();

            if (eventsToArchive.Any())
            {
                if (_archivedEvents.TryGetValue(aggregateId, out List<Event> archivedEvents))
                {
                    archivedEvents.AddRange(eventsToArchive);
                }
                else
                {
                    _archivedEvents.Add(aggregateId, eventsToArchive);
                }

                _persistedEvents[aggregateId] = persistedEvents.Where(e => !archivePredicate(e)).ToList();
            }
        }
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
}

//public class EventStoreArchive
//{
//    private readonly Dictionary<Guid, List<Event>> _archivedEvents;

//    public EventStoreArchive()
//    {
//        _archivedEvents = new Dictionary<Guid, List<Event>>();
//    }

//    public void Archive(Guid aggregateId, List<Event> eventsToArchive)
//    {
//        if (_archivedEvents.TryGetValue(aggregateId, out List<Event> events))
//        {
//            events.AddRange(eventsToArchive);
//        }
//        else
//        {
//            _archivedEvents.Add(aggregateId, eventsToArchive);
//        }
//    }
//}

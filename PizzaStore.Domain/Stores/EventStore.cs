using PizzaStore.Domain.Infrastructure;

namespace PizzaStore.Domain.Stores;

internal interface IEventStore
{
    void Archive(Guid aggregateId, Func<Event, bool> archivePredicate);
    IEnumerable<Event> GetEvents(Guid aggregateId);
    void Publish(Guid aggregateId, Event @event);
}

internal class LocalEventStore : IEventStore
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
        if (_persistedEvents.TryGetValue(aggregateId, out List<Event> events))
        {
            var eventsToArchive = events.Where(archivePredicate).ToList();

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

                _persistedEvents[aggregateId] = archivedEvents.Where(e => !archivePredicate(e)).ToList();
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

    public void Publish(Guid aggregateId, Event @event)
    {
        if (_persistedEvents.TryGetValue(aggregateId, out List<Event> events))
        {
            events.Add(@event);
        }
        else
        {
            _persistedEvents.Add(aggregateId, new List<Event> { @event });
        }
    }
}

//internal class EventStoreArchive
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

using PizzaStore.Core.Abstractions;

namespace PizzaStore.Core.Infrastructure.Data.Projections.Engine;

public class EventProjectionRouter
{
    private readonly IEnumerable<IProjection> _allProjections;

    public EventProjectionRouter(IEnumerable<IProjection> allProjections)
    {
        _allProjections = allProjections;
    }

    public void Dispatch(Event @event)
    {
        var eventProjections = _allProjections.Where(p => p.ShouldProcess(@event));

        foreach (var projection in eventProjections)
        {
            projection.Dispatch(@event);
        }
    }
}

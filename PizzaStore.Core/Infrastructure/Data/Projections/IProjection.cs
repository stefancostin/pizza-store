using PizzaStore.Core.Abstractions;

namespace PizzaStore.Core.Infrastructure.Data.Projections;

public interface IProjection
{
    void Dispatch(Event @event);
    bool ShouldProcess(Event @event);
}

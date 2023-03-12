using PizzaStore.Domain.Infrastructure;
using PizzaStore.Domain.Warehousing;

namespace PizzaStore.Domain.CommandHandlers;

internal class InventoryItemCreator : CommandHandler<CreateInventoryItem, InventoryItem>
{
    public InventoryItemCreator(
        Func<Guid, IEnumerable<Event>> eventStream, Action<EventMessage> publishEvent) 
        : base(eventStream, publishEvent)
    {
    }
}

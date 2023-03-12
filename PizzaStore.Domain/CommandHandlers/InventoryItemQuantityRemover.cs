using PizzaStore.Domain.Infrastructure;
using PizzaStore.Domain.Warehousing;

namespace PizzaStore.Domain.CommandHandlers;

internal class InventoryItemQuantityRemover : CommandHandler<RemoveItemQuantity, InventoryItem>
{
    public InventoryItemQuantityRemover(
        Func<Guid, IEnumerable<Event>> eventStream, Action<EventMessage> publishEvent)
        : base(eventStream, publishEvent)
    {
    }
}

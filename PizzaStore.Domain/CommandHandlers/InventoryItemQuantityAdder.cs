using PizzaStore.Domain.Infrastructure;
using PizzaStore.Domain.Warehousing;

namespace PizzaStore.Domain.CommandHandlers;

internal class InventoryItemQuantityAdder : CommandHandler<AddItemQuantity, InventoryItem>
{
    public InventoryItemQuantityAdder(
        Func<Guid, IEnumerable<Event>> eventStream, Action<EventMessage> publishEvent) 
        : base(eventStream, publishEvent)
    {
    }
}

using PizzaStore.Core.EventStores;
using PizzaStore.Core.Inventory;

namespace PizzaStore.Core.CommandHandlers;

internal class InventoryItemQuantityRemover : CommandHandler<RemoveItemQuantity, InventoryItem>
{
    public InventoryItemQuantityRemover(IEventStore eventStore) : base(eventStore)
    {
    }
}

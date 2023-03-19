using PizzaStore.Core.EventStores;
using PizzaStore.Core.Inventory;

namespace PizzaStore.Core.CommandHandlers;

internal class InventoryItemQuantityAdder : CommandHandler<AddItemQuantity, InventoryItem>
{
    public InventoryItemQuantityAdder(IEventStore eventStore) : base(eventStore)
    {
    }
}

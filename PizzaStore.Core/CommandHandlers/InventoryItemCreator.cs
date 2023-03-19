using PizzaStore.Core.EventStores;
using PizzaStore.Core.Inventory;

namespace PizzaStore.Core.CommandHandlers;

internal class InventoryItemCreator : CommandHandler<CreateInventoryItem, InventoryItem>
{
    public InventoryItemCreator(IEventStore eventStore) : base(eventStore)
    {
    }
}

using PizzaStore.Core.Infrastructure;
using PizzaStore.Core.Infrastructure.EventStores;
using PizzaStore.Core.Warehousing.Inventory;

namespace PizzaStore.Core.Warehousing.CommandHandlers;

internal class InventoryItemQuantityAdder : CommandHandler<AddItemQuantity, InventoryItem>
{
    public InventoryItemQuantityAdder(IEventStore eventStore) : base(eventStore)
    {
    }
}

using PizzaStore.Core.Infrastructure;
using PizzaStore.Core.Infrastructure.EventStores;
using PizzaStore.Core.Warehousing.Inventory;

namespace PizzaStore.Core.Warehousing.CommandHandlers;

internal class InventoryItemQuantityRemover : CommandHandler<RemoveItemQuantity, InventoryItem>
{
    public InventoryItemQuantityRemover(IEventStore eventStore) : base(eventStore)
    {
    }
}

using PizzaStore.Core.Infrastructure;
using PizzaStore.Core.Infrastructure.EventStores;
using PizzaStore.Core.Warehousing.Inventory;

namespace PizzaStore.Core.Warehousing.CommandHandlers;

internal class InventoryItemCreator : CommandHandler<CreateInventoryItem, InventoryItem>
{
    public InventoryItemCreator(IEventStore eventStore) : base(eventStore)
    {
    }
}

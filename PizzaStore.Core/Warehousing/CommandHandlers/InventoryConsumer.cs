using PizzaStore.Core.Infrastructure;
using PizzaStore.Core.Infrastructure.EventStores;
using PizzaStore.Core.Warehousing.Inventory;

namespace PizzaStore.Core.Warehousing.CommandHandlers;

internal class InventoryConsumer : CommandHandler<ConsumeInventory, InventoryItem>
{
    public InventoryConsumer(IEventStore eventStore) : base(eventStore)
    {
    }
}

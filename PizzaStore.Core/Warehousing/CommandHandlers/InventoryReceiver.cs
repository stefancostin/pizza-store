using PizzaStore.Core.Infrastructure;
using PizzaStore.Core.Infrastructure.EventStores;
using PizzaStore.Core.Warehousing.Inventory;

namespace PizzaStore.Core.Warehousing.CommandHandlers;

internal class InventoryReceiver : CommandHandler<ReceiveInventory, InventoryItem>
{
    public InventoryReceiver(IEventStore eventStore) : base(eventStore)
    {
    }
}

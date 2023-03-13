using PizzaStore.Domain.Stores;
using PizzaStore.Domain.Warehousing;

namespace PizzaStore.Domain.CommandHandlers;

internal class InventoryItemQuantityRemover : CommandHandler<RemoveItemQuantity, InventoryItem>
{
    public InventoryItemQuantityRemover(IEventStore eventStore) : base(eventStore)
    {
    }
}

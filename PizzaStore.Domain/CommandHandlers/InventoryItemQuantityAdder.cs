using PizzaStore.Domain.Stores;
using PizzaStore.Domain.Warehousing;

namespace PizzaStore.Domain.CommandHandlers;

internal class InventoryItemQuantityAdder : CommandHandler<AddItemQuantity, InventoryItem>
{
    public InventoryItemQuantityAdder(IEventStore eventStore) : base(eventStore)
    {
    }
}

using PizzaStore.Domain.Warehousing;

namespace PizzaStore.Tests;

public partial class WhenCreateInventoryItem
{
    protected CreateInventoryItem CreateInventoryItem()
    {
        return new CreateInventoryItem(InventoryItemId, InventoryItemName);
    }
}

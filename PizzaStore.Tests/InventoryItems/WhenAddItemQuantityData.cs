using PizzaStore.Domain.Warehousing;

namespace PizzaStore.Tests;

public partial class WhenAddItemQuantity
{
    protected AddItemQuantity AddItemQuantityToInventory(int quantity)
    {
        return new AddItemQuantity(InventoryItemId, quantity);
    }
}

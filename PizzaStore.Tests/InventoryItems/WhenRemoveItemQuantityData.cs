using PizzaStore.Domain.Warehousing;

namespace PizzaStore.Tests;

public partial class WhenRemoveItemQuantity
{
    protected RemoveItemQuantity RemoveItemQuantity(int quantity)
    {
        return new RemoveItemQuantity(InventoryItemId, quantity);
    }
}

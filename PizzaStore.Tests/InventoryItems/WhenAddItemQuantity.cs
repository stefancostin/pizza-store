using PizzaStore.Tests.InventoryItems;

namespace PizzaStore.Tests;

public partial class WhenAddItemQuantity : InventoryItemTests
{
    [Fact]
    public void ThenItemQuantityIsAddedToInventory()
    {
        Given(
            InventoryItemIsCreated());

        When(
            AddItemQuantityToInventory(10));

        Then(
            ItemQuantityIsAddedToInventory(10));
    }
}

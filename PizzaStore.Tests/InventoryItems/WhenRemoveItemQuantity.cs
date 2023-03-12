using PizzaStore.Tests.InventoryItems;

namespace PizzaStore.Tests;

public partial class WhenRemoveItemQuantity : InventoryItemTests
{
    [Fact]
    public void AndSufficientStockThenItemQuantityIsRemoved()
    {
        Given(
            InventoryItemIsCreated(),
            ItemQuantityIsAddedToInventory(10));

        When(
            RemoveItemQuantity(10));

        Then(
            ItemQuantityIsRemovedFromInventory(10));
    }

    [Fact]
    public void AndInsufficientStockThenItemQuantityIsNotRemoved()
    {
        Given(
            InventoryItemIsCreated());

        When(
            RemoveItemQuantity(10));

        Then(
            InsuffucientItemQuantityInInventory());
    }
}

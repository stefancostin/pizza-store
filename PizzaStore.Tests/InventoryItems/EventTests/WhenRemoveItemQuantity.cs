using PizzaStore.Tests.Infrastructure;

namespace PizzaStore.Tests;

public class WhenRemoveItemQuantity : EventPipelineTests
{
    [Fact]
    public void AndSufficientStockThenItemQuantityIsRemoved()
    {
        Given(
            InventoryItemIsCreated(),
            ItemQuantityIsAddedToInventory(10));

        When(
            RemoveItemQuantityFromInventory(10));

        Then(
            ItemQuantityIsRemovedFromInventory(10));
    }

    [Fact]
    public void AndInsufficientStockThenItemQuantityIsNotRemoved()
    {
        Given(
            InventoryItemIsCreated());

        When(
            RemoveItemQuantityFromInventory(10));

        Then(
            InsuffucientItemQuantityInInventory());
    }
}

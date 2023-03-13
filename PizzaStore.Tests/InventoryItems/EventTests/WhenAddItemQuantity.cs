using PizzaStore.Tests.Infrastructure;

namespace PizzaStore.Tests.InventoryItems.EventTests;

public class WhenAddItemQuantity : EventPipelineTests
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

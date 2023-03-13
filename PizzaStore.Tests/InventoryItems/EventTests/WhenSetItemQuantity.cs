using PizzaStore.Domain.Warehousing;
using PizzaStore.Tests.Infrastructure;

namespace PizzaStore.Tests.InventoryItems;

public class WhenSetItemQuantity : EventPipelineTests
{
    [Fact]
    public void ThenItemQuantityIsSet()
    {
        Given(
            InventoryItemIsCreated(),
            ItemQuantityIsAddedToInventory(10));

        When(
            SetItemQuantity(5));

        Then(
            ItemQuantityIsSetInInventory(5));
    }

    [Fact]
    public void ThenStockOperationEventsAreArchived()
    {
        Given(
            InventoryItemIsCreated(),
            ItemQuantityIsAddedToInventory(10),
            ItemQuantityIsRemovedFromInventory(5));

        When(
            SetItemQuantity(5));

        ThenAll(
            InventoryItemIsCreated(),
            ItemQuantityIsSetInInventory(5));
    }
}

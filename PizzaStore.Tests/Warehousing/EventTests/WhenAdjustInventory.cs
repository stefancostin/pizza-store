using PizzaStore.Tests.Infrastructure;

namespace PizzaStore.Tests.Warehousing.EventTests;

public class WhenAdjustInventory : EventPipelineTests
{
    [Fact]
    public void ThenItemQuantityIsSet()
    {
        Given(
            InventoryItemIsCreated(),
            ReceivedInInventory(10));

        When(
            AdjustInventory(5));

        Then(
            InventoryIsAdjusted(5));
    }

    [Fact]
    public void ThenStockOperationEventsAreArchived()
    {
        Given(
            InventoryItemIsCreated(),
            ReceivedInInventory(10),
            ConsumedFromInventory(5));

        When(
            AdjustInventory(5));

        ThenAll(
            InventoryItemIsCreated(),
            InventoryIsAdjusted(5));
    }
}

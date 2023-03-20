using PizzaStore.Tests.Infrastructure;

namespace PizzaStore.Tests.Warehousing.EventTests;

public class WhenReceiveInventory : EventPipelineTests
{
    [Fact]
    public void ThenItemQuantityIsAddedToInventory()
    {
        Given(
            InventoryItemIsCreated());

        When(
            ReceiveInventory(10));

        Then(
            ReceivedInInventory(10));
    }
}

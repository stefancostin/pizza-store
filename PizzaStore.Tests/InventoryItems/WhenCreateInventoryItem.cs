using PizzaStore.Tests.InventoryItems;

namespace PizzaStore.Tests;

public partial class WhenCreateInventoryItem : InventoryItemTests
{
    [Fact]
    public void ThenInventoryItemIsCreated()
    {
        Given();

        When(
            CreateInventoryItem());

        Then(
            InventoryItemIsCreated());
    }
}

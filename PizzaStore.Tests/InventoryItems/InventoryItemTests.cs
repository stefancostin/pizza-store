using PizzaStore.Domain.Warehousing;
using PizzaStore.Tests.Infrastructure;

namespace PizzaStore.Tests.InventoryItems
{
    public abstract class InventoryItemTests : TestInfrastructure
    {
        protected readonly static Guid InventoryItemId = Guid.NewGuid();
        protected readonly static string InventoryItemName = "Flour";
        //protected readonly static int Quantity = 100;

        protected InventoryItemCreated InventoryItemIsCreated()
        {
            return new InventoryItemCreated(InventoryItemId, InventoryItemName);
        }

        protected ItemQuantityAdded ItemQuantityIsAddedToInventory(int quantity)
        {
            return new ItemQuantityAdded(InventoryItemId, quantity);
        }

        protected ItemQuantityRemoved ItemQuantityIsRemovedFromInventory(int quantity)
        {
            return new ItemQuantityRemoved(InventoryItemId, quantity);
        }

        protected InsufficientItemQuantity InsuffucientItemQuantityInInventory()
        {
            return new InsufficientItemQuantity(InventoryItemId);
        }
    }
}

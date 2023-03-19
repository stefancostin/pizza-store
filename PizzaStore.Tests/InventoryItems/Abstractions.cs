using PizzaStore.Core.Inventory;

namespace PizzaStore.Tests.InventoryItems
{
    internal static class Abstractions
    {
        internal readonly static Guid InventoryItemId = Guid.NewGuid();
        internal readonly static string InventoryItemName = "Flour";

        #region Events

        internal static InventoryItemCreated InventoryItemIsCreated()
        {
            return new InventoryItemCreated(InventoryItemId, InventoryItemName);
        }

        internal static ItemQuantityAdded ItemQuantityIsAddedToInventory(int quantity)
        {
            return new ItemQuantityAdded(InventoryItemId, quantity);
        }

        internal static ItemQuantityRemoved ItemQuantityIsRemovedFromInventory(int quantity)
        {
            return new ItemQuantityRemoved(InventoryItemId, quantity);
        }

        internal static InsufficientItemQuantity InsuffucientItemQuantityInInventory()
        {
            return new InsufficientItemQuantity(InventoryItemId);
        }

        internal static ItemQuantitySet ItemQuantityIsSetInInventory(int quantity)
        {
            return new ItemQuantitySet(InventoryItemId, quantity);
        }

        #endregion

        #region Commands

        internal static CreateInventoryItem CreateInventoryItem()
        {
            return new CreateInventoryItem(InventoryItemId, InventoryItemName);
        }

        public static AddItemQuantity AddItemQuantityToInventory(int quantity)
        {
            return new AddItemQuantity(InventoryItemId, quantity);
        }

        public static RemoveItemQuantity RemoveItemQuantityFromInventory(int quantity)
        {
            return new RemoveItemQuantity(InventoryItemId, quantity);
        }

        public static SetItemQuantity SetItemQuantity(int quantity)
        {
            return new SetItemQuantity(InventoryItemId, quantity);
        }

        #endregion
    }
}

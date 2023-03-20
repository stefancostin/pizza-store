using PizzaStore.Core.Warehousing.Inventory;

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

        internal static InventoryReceived ReceivedInInventory(int quantity)
        {
            return new InventoryReceived(InventoryItemId, quantity);
        }

        internal static InventoryConsumed ConsumedFromInventory(int quantity)
        {
            return new InventoryConsumed(InventoryItemId, quantity);
        }

        internal static InsufficientInventory InsuffucientInventory()
        {
            return new InsufficientInventory(InventoryItemId);
        }

        internal static InventoryAdjusted InventoryIsAdjusted(int quantity)
        {
            return new InventoryAdjusted(InventoryItemId, quantity);
        }

        #endregion

        #region Commands

        internal static CreateInventoryItem CreateInventoryItem()
        {
            return new CreateInventoryItem(InventoryItemId, InventoryItemName);
        }

        public static ReceiveInventory ReceiveInventory(int quantity)
        {
            return new ReceiveInventory(InventoryItemId, quantity);
        }

        public static ConsumeInventory ConsumeInventory(int quantity)
        {
            return new ConsumeInventory(InventoryItemId, quantity);
        }

        public static AdjustInventory AdjustInventory(int quantity)
        {
            return new AdjustInventory(InventoryItemId, quantity);
        }

        #endregion
    }
}

using PizzaStore.Core.Warehousing.Inventory;

namespace PizzaStore.Tests.Warehousing
{
    internal static class Inventory
    {
        internal readonly static Guid ItemId = Guid.NewGuid();
        internal readonly static string ItemName = "Flour";

        #region Events

        internal static InventoryItemCreated InventoryItemIsCreated()
        {
            return new InventoryItemCreated(ItemId, ItemName);
        }

        internal static InventoryReceived ReceivedInInventory(int quantity)
        {
            return new InventoryReceived(ItemId, quantity);
        }

        internal static InventoryConsumed ConsumedFromInventory(int quantity)
        {
            return new InventoryConsumed(ItemId, quantity);
        }

        internal static InsufficientInventory InsuffucientInventory()
        {
            return new InsufficientInventory(ItemId);
        }

        internal static InventoryAdjusted InventoryIsAdjusted(int quantity)
        {
            return new InventoryAdjusted(ItemId, quantity);
        }

        #endregion

        #region Commands

        internal static CreateInventoryItem CreateInventoryItem()
        {
            return new CreateInventoryItem(ItemId, ItemName);
        }

        public static ReceiveInventory ReceiveInventory(int quantity)
        {
            return new ReceiveInventory(ItemId, quantity);
        }

        public static ConsumeInventory ConsumeInventory(int quantity)
        {
            return new ConsumeInventory(ItemId, quantity);
        }

        public static AdjustInventory AdjustInventory(int quantity)
        {
            return new AdjustInventory(ItemId, quantity);
        }

        #endregion
    }
}

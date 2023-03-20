using PizzaStore.Core.Abstractions;

namespace PizzaStore.Core.Warehousing.Inventory;

public class InventoryItem : Aggregate
{
    #region State

    public Guid Id { get; private set; }
    public string Name { get; private set; }
    public int Quantity { get; private set; }

    #endregion

    public override void Apply(Event @event)
    {
        switch (@event)
        {
            case InventoryItemCreated inventoryItemCreated:
                ApplyEvent(inventoryItemCreated);
                return;
            case InventoryReceived inventoryReceived:
                ApplyEvent(inventoryReceived);
                return;
            case InventoryConsumed inventoryConsumed:
                ApplyEvent(inventoryConsumed);
                return;
            case InventoryAdjusted inventoryAdjusted:
                ApplyEvent(inventoryAdjusted);
                return;
            default:
                throw new NotImplementedException("Event type not implemented");
        }
    }

    public override IEnumerable<Event> Handle(Command command)
    {
        switch (command)
        {
            case CreateInventoryItem createInventoryItem:
                return HandleCommand(createInventoryItem);
            case ReceiveInventory receiveInventory:
                return HandleCommand(receiveInventory);
            case ConsumeInventory consumeInventory:
                return HandleCommand(consumeInventory);
            case AdjustInventory adjustInventory:
                return HandleCommand(adjustInventory);
            default:
                throw new NotImplementedException("Command type not implemented");
        }
    }

    #region Events

    private void ApplyEvent(InventoryItemCreated inventoryItemCreated)
    {
        Id = inventoryItemCreated.InventoryItemId;
        Name = inventoryItemCreated.Name;
    }

    private void ApplyEvent(InventoryReceived inventoryReceived)
    {
        Quantity += inventoryReceived.Quantity;
    }

    private void ApplyEvent(InventoryConsumed inventoryConsumed)
    {
        Quantity -= inventoryConsumed.Quantity;
    }

    private void ApplyEvent(InventoryAdjusted inventoryAdjusted)
    {
        Quantity = inventoryAdjusted.Quantity;
    }

    #endregion

    #region Commands

    private IEnumerable<Event> HandleCommand(CreateInventoryItem createInventoryItem)
    {
        yield return new InventoryItemCreated(createInventoryItem.InventoryItemId, createInventoryItem.Name);
    }

    private IEnumerable<Event> HandleCommand(ReceiveInventory receiveInventory)
    {
        yield return new InventoryReceived(receiveInventory.InventoryItemId, receiveInventory.Quantity);
    }

    private IEnumerable<Event> HandleCommand(ConsumeInventory consumeInventory)
    {
        if (Quantity < consumeInventory.Quantity)
        {
            yield return new InsufficientInventory(consumeInventory.InventoryItemId);
            yield break;
        }

        yield return new InventoryConsumed(consumeInventory.InventoryItemId, consumeInventory.Quantity);
    }

    private IEnumerable<Event> HandleCommand(AdjustInventory adjustInventory)
    {
        yield return new InventoryAdjusted(adjustInventory.InventoryItemId, adjustInventory.Quantity);
    }

    #endregion
}

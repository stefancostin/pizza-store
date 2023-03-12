using PizzaStore.Domain.Infrastructure;

namespace PizzaStore.Domain.Warehousing;

internal class InventoryItem : Aggregate
{
    #region State

    private Guid id;
    private string name;
    private int quantity;

    #endregion

    public override void Apply(Event @event)
    {
        switch (@event)
        {
            case InventoryItemCreated inventoryItemCreated:
                ApplyEvent(inventoryItemCreated);
                return;
            case ItemQuantityAdded itemQuantityAdded:
                ApplyEvent(itemQuantityAdded);
                return;
            case ItemQuantityRemoved itemQuantityRemoved:
                ApplyEvent(itemQuantityRemoved);
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
            case AddItemQuantity addItemQuantity:
                return HandleCommand(addItemQuantity);
            case RemoveItemQuantity removeItemQuantity:
                return HandleCommand(removeItemQuantity);
            default:
                throw new NotImplementedException("Command type not implemented");
        }
    }

    #region Events

    private void ApplyEvent(InventoryItemCreated inventoryItemCreated)
    {
        id = inventoryItemCreated.InventoryItemId;
        name = inventoryItemCreated.Name;
    }

    private void ApplyEvent(ItemQuantityAdded itemQuantityAdded)
    {
        quantity += itemQuantityAdded.Quantity;
    }

    private void ApplyEvent(ItemQuantityRemoved itemQuantityRemoved)
    {
        quantity -= itemQuantityRemoved.Quantity;
    }

    #endregion

    #region Commands

    private IEnumerable<Event> HandleCommand(CreateInventoryItem createInventoryItem)
    {
        yield return new InventoryItemCreated(createInventoryItem.InventoryItemId, createInventoryItem.Name);
    }

    private IEnumerable<Event> HandleCommand(AddItemQuantity addItemQuantity)
    {
        yield return new ItemQuantityAdded(addItemQuantity.InventoryItemId, addItemQuantity.Quantity);
    }

    private IEnumerable<Event> HandleCommand(RemoveItemQuantity removeItemQuantity)
    {
        if (quantity < removeItemQuantity.Quantity)
        {
            yield return new InsufficientItemQuantity(removeItemQuantity.InventoryItemId);
            yield break;
        }

        yield return new ItemQuantityRemoved(removeItemQuantity.InventoryItemId, removeItemQuantity.Quantity);
    }

    #endregion
}

using PizzaStore.Core.Abstractions;

namespace PizzaStore.Core.Inventory;

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
            case ItemQuantityAdded itemQuantityAdded:
                ApplyEvent(itemQuantityAdded);
                return;
            case ItemQuantityRemoved itemQuantityRemoved:
                ApplyEvent(itemQuantityRemoved);
                return;
            case ItemQuantitySet itemQuantitySet:
                ApplyEvent(itemQuantitySet);
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
            case SetItemQuantity setItemQuantity:
                return HandleCommand(setItemQuantity);
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

    private void ApplyEvent(ItemQuantityAdded itemQuantityAdded)
    {
        Quantity += itemQuantityAdded.Quantity;
    }

    private void ApplyEvent(ItemQuantityRemoved itemQuantityRemoved)
    {
        Quantity -= itemQuantityRemoved.Quantity;
    }

    private void ApplyEvent(ItemQuantitySet itemQuantitySet)
    {
        Quantity = itemQuantitySet.Quantity;
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
        if (Quantity < removeItemQuantity.Quantity)
        {
            yield return new InsufficientItemQuantity(removeItemQuantity.InventoryItemId);
            yield break;
        }

        yield return new ItemQuantityRemoved(removeItemQuantity.InventoryItemId, removeItemQuantity.Quantity);
    }

    private IEnumerable<Event> HandleCommand(SetItemQuantity setItemQuantity)
    {
        yield return new ItemQuantitySet(setItemQuantity.InventoryItemId, setItemQuantity.Quantity);
    }

    #endregion
}

using PizzaStore.Domain.CommandHandlers;
using PizzaStore.Domain.Infrastructure;
using PizzaStore.Domain.Warehousing;

namespace PizzaStore.Domain;

public class CommandRouter
{
    private readonly Func<Guid, IEnumerable<Event>> _eventStream;
    private readonly Action<EventMessage> _publishEvent;

    public CommandRouter(
        Func<Guid, IEnumerable<Event>> eventStream,
        Action<EventMessage> publishEvent)
    {
        _eventStream = eventStream;
        _publishEvent = publishEvent;
    }

    public void HandleCommand(object command)
    {
        switch (command)
        {
            case CreateInventoryItem createInventoryItem:
                var inventoryItemCreator = new InventoryItemCreator(_eventStream, _publishEvent);
                inventoryItemCreator.Handle(createInventoryItem);
                return;
            case AddItemQuantity addItemQuantityToInventory:
                var inventoryItemAdder = new InventoryItemQuantityAdder(_eventStream, _publishEvent);
                inventoryItemAdder.Handle(addItemQuantityToInventory);
                return;
            case RemoveItemQuantity removeItemQuantityFromInventory:
                var inventoryItemRemover = new InventoryItemQuantityRemover(_eventStream, _publishEvent);
                inventoryItemRemover.Handle(removeItemQuantityFromInventory);
                return;
        }
    }
}

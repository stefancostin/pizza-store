﻿using PizzaStore.Core.Infrastructure.EventStores;
using PizzaStore.Core.Warehousing.CommandHandlers;
using PizzaStore.Core.Warehousing.Inventory;

namespace PizzaStore.Core.Infrastructure;

public class CommandRouter
{
    private readonly IEventStore _eventStore;

    public CommandRouter(IEventStore eventStore)
    {
        _eventStore = eventStore;
    }

    public void HandleCommand(object command)
    {
        switch (command)
        {
            case CreateInventoryItem createInventoryItem:
                var inventoryItemCreator = new InventoryItemCreator(_eventStore);
                inventoryItemCreator.Handle(createInventoryItem);
                return;
            case AddItemQuantity addItemQuantityToInventory:
                var inventoryItemAdder = new InventoryItemQuantityAdder(_eventStore);
                inventoryItemAdder.Handle(addItemQuantityToInventory);
                return;
            case RemoveItemQuantity removeItemQuantityFromInventory:
                var inventoryItemRemover = new InventoryItemQuantityRemover(_eventStore);
                inventoryItemRemover.Handle(removeItemQuantityFromInventory);
                return;
            case SetItemQuantity setItemQuantityInInventory:
                var inventoryItemSetter = new InventoryItemQuantitySetter(_eventStore);
                inventoryItemSetter.Handle(setItemQuantityInInventory);
                return;
        }
    }
}
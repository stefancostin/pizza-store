using PizzaStore.Core.Infrastructure.EventStores;
using PizzaStore.Core.Catalogue.CommandHandlers;
using PizzaStore.Core.Catalogue.Recipes;
using PizzaStore.Core.Sales.CommandHandlers;
using PizzaStore.Core.Sales.Orders;
using PizzaStore.Core.Sales.Pizzas;
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
            // Warehousing
            case CreateInventoryItem createInventoryItem:
                var inventoryItemCreator = new InventoryItemCreator(_eventStore);
                inventoryItemCreator.Handle(createInventoryItem);
                return;
            case ReceiveInventory addItemQuantityToInventory:
                var inventoryItemAdder = new InventoryReceiver(_eventStore);
                inventoryItemAdder.Handle(addItemQuantityToInventory);
                return;
            case ConsumeInventory removeItemQuantityFromInventory:
                var inventoryItemRemover = new InventoryConsumer(_eventStore);
                inventoryItemRemover.Handle(removeItemQuantityFromInventory);
                return;
            case AdjustInventory setItemQuantityInInventory:
                var inventoryItemSetter = new InventoryAdjuster(_eventStore);
                inventoryItemSetter.Handle(setItemQuantityInInventory);
                return;

            // Catalogue
            case CreateRecipe createRecipe:
                var recipeCreator = new RecipeCreator(_eventStore);
                recipeCreator.Handle(createRecipe);
                return;

            // Sales
            case CreatePizza createPizza:
                var pizzaCreator = new PizzaCreator(_eventStore);
                pizzaCreator.Handle(createPizza);
                return;
            case CreateOrder createOrder:
                var orderCreator = new OrderCreator(_eventStore);
                orderCreator.Handle(createOrder);
                return;
            case PlaceOrder placeOrder:
                var orderSender = new OrderSender(_eventStore);
                orderSender.Handle(placeOrder);
                return;
        }
    }
}

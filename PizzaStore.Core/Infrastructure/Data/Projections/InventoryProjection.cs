using Microsoft.Extensions.DependencyInjection;
using PizzaStore.Core.Abstractions;
using PizzaStore.Core.Infrastructure.Data;
using PizzaStore.Core.Warehousing.Inventory;

namespace PizzaStore.Core.Infrastructure.Data.Projections;

public class InventoryProjection : IProjection
{
    private readonly IServiceProvider _services;

    public InventoryProjection(IServiceProvider services)
    {
        _services = services;
    }

    public bool ShouldProcess(Event @event) =>
        @event is InventoryReceived ||
        @event is InventoryConsumed ||
        @event is InventoryAdjusted;

    public void Dispatch(Event @event)
    {
        using var readDbContext = _services.CreateScope().ServiceProvider.GetService<ReadContext>();

        var inventory = FindInventory(@event, readDbContext);
        inventory.Quantity = CalculateQuantity(@event, inventory);

        readDbContext.SaveChanges();
    }

    private int CalculateQuantity(Event @event, Inventory inventory)
    {
        switch (@event)
        {
            case InventoryReceived itemQuantityAdded:
                return inventory.Quantity + itemQuantityAdded.Quantity;
            case InventoryConsumed itemQuantityRemoved:
                return inventory.Quantity - itemQuantityRemoved.Quantity;
            case InventoryAdjusted itemQuantitySet:
                return itemQuantitySet.Quantity;
            default:
                throw new NotImplementedException("Event projection not implemented");
        }
    }

    private Inventory FindInventory(Event @event, ReadContext readDbContext)
    {
        var entry = readDbContext.Inventory.Find(@event.AggregateId);

        if (entry is null)
        {
            entry = new Inventory()
            {
                ItemId = @event.AggregateId
            };

            readDbContext.Add(entry);
        }

        return entry;
    }
}

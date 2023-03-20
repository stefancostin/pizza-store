using Microsoft.Extensions.DependencyInjection;
using PizzaStore.Core.Abstractions;
using PizzaStore.Core.Warehousing.Inventory;

namespace PizzaStore.Core.Infrastructure.Data.Projections;

public class InventoryItemsProjection : IProjection
{
    private readonly IServiceProvider _services;

    public InventoryItemsProjection(IServiceProvider services)
    {
        _services = services;
    }

    public bool ShouldProcess(Event @event) => @event is InventoryItemCreated;

    public void Dispatch(Event @event)
    {
        if (@event.AggregateId == Guid.Empty)
        {
            return;
        }

        using var readDbContext = _services.CreateScope().ServiceProvider.GetService<ReadContext>();

        var existingInventoryItem = readDbContext.InventoryItems.Find(@event.AggregateId);

        if (existingInventoryItem is null)
        {
            var inventoryItem = CreateInventoryItem((InventoryItemCreated)@event);

            readDbContext.InventoryItems.Add(inventoryItem);

            readDbContext.SaveChanges();
        }
    }

    private InventoryItem CreateInventoryItem(InventoryItemCreated @event)
    {
        return new InventoryItem() { ItemId = @event.ItemId, Name = @event.Name };
    }
}

using Microsoft.Extensions.DependencyInjection;
using PizzaStore.Core.Abstractions;
using PizzaStore.Core.Infrastructure.Data;
using PizzaStore.Core.Warehousing.Inventory;

namespace PizzaStore.Core.Infrastructure.Data.Projections;

public class InventoryItemsProjection : IProjection
{
    private readonly IServiceProvider _services;

    public bool ShouldProcess(Event @event) => @event is InventoryItemCreated;

    public void Dispatch(Event @event)
    {
        using var readDbContext = _services.CreateScope().ServiceProvider.GetService<ReadContext>();

        var inventoryItem = CreateInventoryItem((InventoryItemCreated)@event);

        readDbContext.InventoryItems.Add(inventoryItem);

        readDbContext.SaveChanges();
    }

    private InventoryItem CreateInventoryItem(InventoryItemCreated @event)
    {
        return new InventoryItem() { ItemId = @event.InventoryItemId, Name = @event.Name };
    }
}

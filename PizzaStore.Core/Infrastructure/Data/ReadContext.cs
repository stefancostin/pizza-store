using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace PizzaStore.Core.Infrastructure.Data;

public class ReadContext : DbContext
{
    public ReadContext(DbContextOptions<ReadContext> options) : base(options)
    {
    }

    public DbSet<InventoryItem> InventoryItems { get; set; }
    public DbSet<Inventory> Inventory { get; set; }
}

public class InventoryItem
{
    [Key]
    public Guid ItemId { get; set; }
    public string Name { get; set; }
}

public class Inventory
{
    [Key]
    public Guid ItemId { get; set; }
    public int Quantity { get; set; }
}

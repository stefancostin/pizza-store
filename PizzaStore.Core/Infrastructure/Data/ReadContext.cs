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

    public DbSet<Recipe> Recipes { get; set; }
    public DbSet<RecipeIngredient> RecipeIngredients { get; set; }

    public DbSet<Pizza> Pizzas { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderItem> OrderItems { get; set; }
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

public class Recipe
{
    [Key]
    public Guid RecipeId { get; set; }
    public string Name { get; set; }
    public ICollection<RecipeIngredient> Ingredients { get; set; }     
}

public class RecipeIngredient
{
    [Key]
    public Guid IngredientId { get; set; }
    public Guid InventoryItemId { get; set; }
    public int Quantity { get; set; }
}

public class Pizza
{
    [Key]
    public Guid PizzaId { get; set; }
    public Guid RecipeId { get; set; }
    public string Name { get; set; }
    public int Price { get; set; }
}

public class Order
{
    [Key]
    public Guid OrderId { get; set; }
    public int Total { get; set; }
    public bool IsPlaced { get; set; }
    public ICollection<OrderItem> OrderLines { get; set; }
}

public class OrderItem
{
    [Key]
    public Guid OrderItemId { get; set; }
    public Guid PizzaId { get; set; }
    public int Price { get; set; }
}

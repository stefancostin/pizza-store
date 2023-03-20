namespace PizzaStore.Core.Catalogue.Recipes;

public class Ingredient
{
    public Guid IngredientId { get; set; }
    public Guid InventoryItemId { get; set; }
    public int Quantity { get; set; }
}

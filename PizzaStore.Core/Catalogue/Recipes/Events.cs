using PizzaStore.Core.Abstractions;

namespace PizzaStore.Core.Catalogue.Recipes;

public record struct IngredientCreated(Guid IngredientId, Guid InventoryItemId, int Quantity) : Event
{
    public Guid AggregateId => IngredientId;
}

public record struct RecipeCreated(Guid RecipeId, string Name, IEnumerable<Ingredient> Ingredients) : Event
{
    public Guid AggregateId => RecipeId;
}

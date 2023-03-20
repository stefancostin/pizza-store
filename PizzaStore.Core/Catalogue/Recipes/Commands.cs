using PizzaStore.Core.Abstractions;

namespace PizzaStore.Core.Catalogue.Recipes;

public record struct CreateIngredient(Guid IngredientId, string Name, int Quantity) : Command
{
    public Guid AggregateId => IngredientId;
}

public record struct CreateRecipe(Guid RecipeId, string Name, IEnumerable<Ingredient> Ingredients) : Command
{
    public Guid AggregateId => RecipeId;
}

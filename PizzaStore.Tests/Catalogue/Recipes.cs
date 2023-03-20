
using PizzaStore.Core.Catalogue.Recipes;

namespace PizzaStore.Tests.Catalogue;

internal static class Recipes
{
    internal readonly static Guid RecipeId = Guid.NewGuid();
    internal readonly static string Name = "Pizza Margherita";
    internal readonly static IEnumerable<Ingredient> Ingredients = new List<Ingredient>()
    {
        new Ingredient()
        {
            IngredientId = Guid.NewGuid(),
            InventoryItemId = Guid.NewGuid(),
            Quantity = 100,
        }
    };

    #region Events

    internal static RecipeCreated PizzaRecipeIsCreated()
    {
        return new RecipeCreated(RecipeId, Name, Ingredients);
    }

    #endregion

    #region Commands

    internal static CreateRecipe CreatePizzaRecipe()
    {
        return new CreateRecipe(RecipeId, Name, Ingredients);
    }

    #endregion
}

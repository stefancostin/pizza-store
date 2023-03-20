using Microsoft.Extensions.DependencyInjection;
using PizzaStore.Core.Abstractions;
using PizzaStore.Core.Catalogue.Recipes;

namespace PizzaStore.Core.Infrastructure.Data.Projections;

public class RecipesProjection : IProjection
{
    private readonly IServiceProvider _services;

    public RecipesProjection(IServiceProvider services)
    {
        _services = services;
    }

    public bool ShouldProcess(Event @event) => @event is RecipeCreated;

    public void Dispatch(Event @event)
    {
        if (@event.AggregateId == Guid.Empty)
        {
            return;
        }

        using var readDbContext = _services.CreateScope().ServiceProvider.GetService<ReadContext>();

        var recipe = CreateRecipe((RecipeCreated)@event);

        readDbContext.Recipes.Add(recipe);

        readDbContext.SaveChanges();
    }

    private Recipe CreateRecipe(RecipeCreated @event)
    {
        return new Recipe()
        {
            RecipeId = @event.RecipeId,
            Name = @event.Name,
            Ingredients = @event.Ingredients.Select(i => new RecipeIngredient()
            {
                IngredientId = i.IngredientId,
                InventoryItemId = i.InventoryItemId,
                Quantity = i.Quantity
            }).ToList()
        };
    }
}

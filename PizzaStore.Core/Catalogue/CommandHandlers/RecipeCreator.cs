using PizzaStore.Core.Infrastructure;
using PizzaStore.Core.Infrastructure.EventStores;
using PizzaStore.Core.Catalogue.Recipes;

namespace PizzaStore.Core.Catalogue.CommandHandlers;

internal class RecipeCreator : CommandHandler<CreateRecipe, Recipe>
{
    public RecipeCreator(IEventStore eventStore) : base(eventStore)
    {
    }
}

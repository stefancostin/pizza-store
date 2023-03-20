using FluentAssertions;
using PizzaStore.Core.Catalogue.Recipes;
using PizzaStore.Tests.Infrastructure;

namespace PizzaStore.Tests.Catalogue.StateTests;

public class WhenCreateRecipe : AggregateStateTests<Recipe>
{
    [Fact]
    public void ThenNewRecipeIsCreated()
    {
        Given();

        When(
            CreatePizzaRecipe());

        Then(
            recipe =>
            {
                recipe.RecipeId.Should().Be(RecipeId);
                recipe.Name.Should().Be(Name);
                recipe.Ingredients.Should().Equal(Ingredients);
            });
    }
}

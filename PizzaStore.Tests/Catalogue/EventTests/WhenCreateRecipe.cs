using PizzaStore.Tests.Infrastructure;

namespace PizzaStore.Tests.Catalogue.EventTests;

public class WhenCreateRecipe : EventPipelineTests
{
    [Fact]
    public void ThenNewRecipeIsCreated()
    {
        Given();

        When(
            CreatePizzaRecipe());

        Then(
            PizzaRecipeIsCreated());
    }
}

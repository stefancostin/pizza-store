using PizzaStore.Core.Abstractions;

namespace PizzaStore.Core.Catalogue.Recipes;

public class Recipe : Aggregate
{
    public Guid RecipeId { get; private set; }
    public string Name { get; private set; }
    public IEnumerable<Ingredient> Ingredients { get; private set; }

    public Recipe()
    {
        Ingredients = new List<Ingredient>();
    }

    public override void Apply(Event @event)
    {
        switch (@event)
        {
            case RecipeCreated recipeCreated:
                ApplyEvent(recipeCreated);
                return;
            default:
                throw new NotImplementedException("Event type not implemented");
        }
    }

    public override IEnumerable<Event> Handle(Command command)
    {
        switch (command)
        {
            case CreateRecipe createRecipe:
                return HandleCommand(createRecipe);
            default:
                throw new NotImplementedException("Command type not implemented");
        }
    }

    private void ApplyEvent(RecipeCreated recipeCreated)
    {
        RecipeId = recipeCreated.RecipeId;
        Name = recipeCreated.Name;
        Ingredients = recipeCreated.Ingredients;
    }

    private IEnumerable<Event> HandleCommand(CreateRecipe createRecipe)
    {
        yield return new RecipeCreated(createRecipe.RecipeId, createRecipe.Name, createRecipe.Ingredients);
    }
}

using CookiesCookbookCSharpAssignment.Recipes.Ingredients;

namespace CookiesCookbookCSharpAssignment.Recipes
{
    public class Recipe
    {
        public IEnumerable<Ingredient> Ingredients { get; }
        public Recipe(IEnumerable<Ingredient> ingredients) 
        {
             Ingredients = ingredients;
        }

        public override string ToString()
        {
            var steps = new List<string>();
            int counter = 1;
            foreach(var ingredient in Ingredients)
            {
                steps.Add($" { counter }: {ingredient.Name}. {ingredient.PreparationInstructions}");
                counter++;
            }
            return string.Join(Environment.NewLine, steps);
        }

    }

}

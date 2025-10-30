
using CookiesCookbookCSharpAssignment.Recipes.Ingredients;
using CookiesCookbookCSharpAssignment.Recipes;

namespace CookiesCookbookCSharpAssignment.App
{
    public interface IRecipesUserInteraction
    {
        void ShowMessage(string message);
        void ExitApp();
        void PrintExistingRecipes(IEnumerable<Recipe> allRecipes);
        void PromptToCreateRecipe();
        IEnumerable<Ingredient> ReadIngredientsFromUser();
    }

}

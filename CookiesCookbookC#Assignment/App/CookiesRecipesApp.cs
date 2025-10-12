using CookiesCookbookCSharpAssignment.Recipes;

namespace CookiesCookbookCSharpAssignment.App
{
    public class CookiesRecipesApp
    {
        private readonly IRecipesRepository _recipesRepository;
        //private readonly IRecipesUserInteraction _recipesConsoleUserInteraction = new RecipesConsoleUserInteraction();
        private readonly IRecipesUserInteraction _recipesUserInteraction;

        public CookiesRecipesApp(
            IRecipesRepository recipesRepository,
            IRecipesUserInteraction recipesConsoleUserInteraction
        )
        {
            _recipesRepository = recipesRepository;
            _recipesUserInteraction = recipesConsoleUserInteraction;
        }

        public void Run(string filePath)
        {
            var allRecipes = _recipesRepository.Read(filePath);
            _recipesUserInteraction.PrintExistingRecipes(allRecipes);

            _recipesUserInteraction.PromptToCreateRecipe();


            var ingredients = _recipesUserInteraction.ReadIngredientsFromUser();

            if (ingredients.Count() > 0)
            {
                var recipe = new Recipe(ingredients);
                allRecipes.Add(recipe);
                _recipesRepository.Write(filePath, allRecipes);

                _recipesUserInteraction.ShowMessage($"Recipe Added: ");
                _recipesUserInteraction.ShowMessage($"{recipe.ToString()}");
            }
            else
            {
                _recipesUserInteraction.ShowMessage($"No Ingredients Have been Selected. Recipe Will not be Saved.");
            }


            _recipesUserInteraction.ExitApp();


        }
    }

}


using CookiesCookbookCSharpAssignment.DataAccess;
using CookiesCookbookCSharpAssignment.Recipes.Ingredients;

namespace CookiesCookbookCSharpAssignment.Recipes
{
    public class RecipesRepository : IRecipesRepository
    {
        private readonly IStringsRepository _stringsRepository;
        private readonly IIngredientsRegister _ingredientsRegister;
        private const string Separator = ",";

        public RecipesRepository(
            IStringsRepository stringsRepository,
            IIngredientsRegister ingredientsRegister
        )
        {
            _stringsRepository = stringsRepository;
            _ingredientsRegister = ingredientsRegister;
        }

        public List<Recipe> Read(string filePath)
        {

            //List<string> recipesFromFile = _stringsRepository.Read(filePath);

            //return recipesFromFile
            //    .Select(recipeFromFile => RecipeFromString(recipeFromFile)).ToList();

            //return recipesFromFile
            //    .Select(RecipeFromString).ToList();

            return _stringsRepository.Read(filePath)
                .Select(RecipeFromString).ToList();
        }

        //public List<Recipe> Read(string filePath)
        //{

        //    //List<string> recipesFromFile = _stringsRepository.Read(filePath);

        //    //return recipesFromFile
        //    //    .Select(recipeFromFile => RecipeFromString(recipeFromFile)).ToList();

        //    //return recipesFromFile
        //    //    .Select(RecipeFromString).ToList();

        //    return _stringsRepository.Read(filePath)
        //        .Select(RecipeFromString).ToList();


        //    //var recipes = new List<Recipe>();

        //    //foreach (var recipeFromFile in recipesFromFile)
        //    //{
        //    //    var recipe = RecipeFromString(recipeFromFile);
        //    //    recipes.Add(recipe);
        //    //}

        //    //return recipes;



        private Recipe RecipeFromString(string recipeFromFile)
        {
            //var ingredients = new List<Ingredient>();
            //ingredients = recipeFromFile
            //                .Split(Separator)
            //                .Select(textualId => _ingredientsRegister.GetById(int.Parse(textualId))).ToList();

            //ingredients = recipeFromFile
            //    .Split(Separator)
            //    .Select(int.Parse)
            //    .Select(_ingredientsRegister.GetById).ToList();

            //return new Recipe(ingredients);

            return new Recipe(
                recipeFromFile
                .Split(Separator)
                .Select(int.Parse)
                .Select(_ingredientsRegister.GetById).ToList()
            );

        }

        //private Recipe RecipeFromString(string recipeFromFile)
        //{
        //    var textualIds = recipeFromFile.Split(Separator);
        //    var ingredients = new List<Ingredient>();

        //    foreach (var textualId in textualIds)
        //    {
        //        var id = int.Parse(textualId);
        //        var ingrediant = _ingredientsRegister.GetById(id);
        //        ingredients.Add(ingrediant);
        //    }

        //    return new Recipe(ingredients);
        //}

        public void Write(string filePath, List<Recipe> allRecipes)
        {
            var recipesAsStrings = allRecipes.Select(
                recipe => string.Join(
                    Separator,
                    recipe.Ingredients.Select(ingredient => ingredient.Id))).ToList();

            _stringsRepository.Write(filePath, recipesAsStrings);
        }

        //public void Write(string filePath, List<Recipe> allRecipes)
        //{
        //    var recipesAsStrings = new List<string>();
        //    foreach (Recipe recipe in allRecipes)
        //    {
        //        var allIds = new List<int>();
        //        foreach (Ingredient ingredient in recipe.Ingredients)
        //        {
        //            allIds.Add(ingredient.Id);
        //        }
        //        recipesAsStrings.Add(string.Join(Separator, allIds));
        //    }
        //    _stringsRepository.Write(filePath, recipesAsStrings);
        //}
    }

}

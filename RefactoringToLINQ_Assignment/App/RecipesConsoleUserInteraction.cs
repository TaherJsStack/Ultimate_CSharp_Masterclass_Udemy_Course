
using CookiesCookbookCSharpAssignment.Recipes.Ingredients;
using CookiesCookbookCSharpAssignment.Recipes;

namespace CookiesCookbookCSharpAssignment.App
{
    public class RecipesConsoleUserInteraction : IRecipesUserInteraction
    {

        private readonly IIngredientsRegister _ingredientsRegister;

        public RecipesConsoleUserInteraction(IIngredientsRegister ingredientsRegister)
        {
            _ingredientsRegister = ingredientsRegister;
        }

        public void ShowMessage(string message)
        {
            Console.WriteLine(message);
        }
        public void ExitApp()
        {
            Console.WriteLine("Press any key to close.");
            Console.ReadKey();
        }

        public void PrintExistingRecipes(IEnumerable<Recipe> allRecipes)
        {
            if (allRecipes.Count() > 0)
            {
                Console.WriteLine("Existing recipes are: " + Environment.NewLine);
                //int counter = 1;
                //foreach (Recipe recipe in allRecipes)
                //{
                //    Console.WriteLine($"******************: {counter} :******************");
                //    Console.WriteLine(recipe.ToString());
                //    Console.WriteLine(Environment.NewLine);
                //    counter++;
                //}

                Console.WriteLine(
                    string.Join(
                        Environment.NewLine, 
                        allRecipes.Select((recipe, index) => 
                            $"************** { index+1 } *****************"+ 
                            Environment.NewLine +
                            recipe+
                            Environment.NewLine
                        )
                    )
                 );


            }
            else
            {

            }
        }

        public void PromptToCreateRecipe()
        {
            Console.WriteLine("Create a new cookie recipe!");
            Console.WriteLine("Available ingredients are:");

            Console.WriteLine(string.Join(Environment.NewLine, _ingredientsRegister.All.Select(ingredient => ingredient)));

            //foreach (Ingredient ingredient in _ingredientsRegister.All)
            //{
            //    Console.WriteLine(ingredient.ToString());
            //}

        }

        public IEnumerable<Ingredient> ReadIngredientsFromUser()
        {

            bool shallstop = false;
            var ingredients = new List<Ingredient>();

            while (!shallstop)
            {
                Console.WriteLine("Add an Ingredient by it's ID, or type anything else if finished ");
                var userInput = Console.ReadLine();

                if (int.TryParse(userInput, out int id))
                {
                    var selectedIngredient = _ingredientsRegister.GetById(id);

                    if (selectedIngredient is not null)
                    {
                        ingredients.Add(selectedIngredient);
                    }

                }
                else
                {
                    shallstop = true;
                }

            }

            return ingredients;
        }
    }

}

namespace CookiesCookbookCSharpAssignment.Recipes.Ingredients
{
    public class IngredientsRegister : IIngredientsRegister
    {
        public IEnumerable<Ingredient> All { get; } = new List<Ingredient>()
    {
        new BakingPowder(),
        new Butter(),
        new Egg(),
        new Milk(),
        new Salt(),
        new SpeltFlour(),
        new Sugar(),
        new WheatFlour()
    };

        public Ingredient GetById(int id)
        {
            Ingredient ingredient;
            foreach (var item in All)
            {
                if (item.Id == id)
                {
                    ingredient = item;
                    return item;
                }
            }
            return null;
        }
    }

}

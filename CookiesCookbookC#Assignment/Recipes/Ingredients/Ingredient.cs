namespace CookiesCookbookCSharpAssignment.Recipes.Ingredients
{
    public abstract class Ingredient
    {
        public abstract int Id { get; }
        public abstract string Name { get; }
        public virtual string PreparationInstructions => $"Add to Other ingredients";
        //public abstract string Description { get; }
        //public abstract string Type { get; }

        public override string ToString() => $"{Id}: {Name}";
    }
}

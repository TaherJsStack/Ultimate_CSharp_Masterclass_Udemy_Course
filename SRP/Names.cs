
namespace SRP_APP
{
    public class Names
    {
        public List<string> NamesList { get; } = new List<string>();

        private readonly NamesValidator _nameValidator = new NamesValidator();

        public void AddNames(List<string> stringsTextualr)
        {
            foreach (var name in stringsTextualr)
            {
                AddName(name);
            }
        }

        public void AddName(string name)
        {
            //if (NamesValidators.IsValidName(name))
            //if (new NamesValidators().IsValidName(name))
            if (_nameValidator.IsValid(name))
            {
                NamesList.Add(name);
            }
        }


    }

}

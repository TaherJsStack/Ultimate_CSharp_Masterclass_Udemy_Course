
namespace SRP_APP
{
    public class NamesValidator
    {
        //public static bool IsValidName(string name)
        public bool IsValid(string name)
        {
            return
                name.Length >= 2 &&
                name.Length < 25 &&
                char.IsUpper(name[0]) &&
                name.All(char.IsLetter);
        }
    }
}

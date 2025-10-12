
namespace SRP_APP
{
    public class NamesFormattor
    {
        public string Format(List<string> AllNames) =>
            string.Join(Environment.NewLine, AllNames);

    }
}

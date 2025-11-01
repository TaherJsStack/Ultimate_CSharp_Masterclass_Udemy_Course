using StarWarsPlanetsStats_Assignment.Model;

namespace StarWarsPlanetsStats_Assignment.UserInteractions
{
    public class PlanetsStatsUserInteractor : IPlanetsStatsUserInteractor
    {

        private readonly IUserInteractor _userInteractor;

        public PlanetsStatsUserInteractor(IUserInteractor userInteractor)
        {
            _userInteractor = userInteractor;
        }

        public void Show(IEnumerable<Planet> planets)
        {
            //Console.WriteLine(string.Join("\n", planets));
            TablePrinter.Print<Planet>(planets);
        }

        public void ShowMessage(string message)
        {
            _userInteractor.ShowMessage("\n");
            _userInteractor.ShowMessage(message);
        }
        public string? ChooseStatisticToBeShown(IEnumerable<string> propertiesThatCanBeChosen)
        {
            _userInteractor.ShowMessage("\n The statistics of which property would you like to see? \n");
            _userInteractor.ShowMessage(string.Join(" \n", propertiesThatCanBeChosen));
            return _userInteractor.ReadFromuser();
        }
    }
}

public static class TablePrinter
{
    public static void Print<T>(IEnumerable<T> items)
    {

        const int columnWidth = 20;

        var properties = typeof(T).GetProperties();

        foreach (var property in properties) 
        {
            Console.Write($"{{0, -{columnWidth}}}|", property.Name);
        }
        Console.WriteLine("");
        Console.WriteLine(new string('_', properties.Length * (columnWidth + 1) ));

        //Console.WriteLine(string.Join("\n", items));

        foreach (var item in items)
        {
            foreach (var property in properties)
            {
                Console.Write(
                    $"{{0, -{columnWidth}}}|", 
                    property.GetValue(item));
            }
            Console.WriteLine("");
        }


    }
}
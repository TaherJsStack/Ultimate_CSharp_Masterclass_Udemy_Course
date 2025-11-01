using StarWarsPlanetsStats_Assignment.Model;

namespace StarWarsPlanetsStats_Assignment.UserInteractions
{
    public interface IPlanetsStatsUserInteractor
    {
        void Show(IEnumerable<Planet> planets);

        void ShowMessage(string message);
        string? ChooseStatisticToBeShown(IEnumerable<string> propertiesThatCanBeChosen);
    }
}
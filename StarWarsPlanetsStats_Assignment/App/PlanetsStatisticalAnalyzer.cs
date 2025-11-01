using StarWarsPlanetsStats_Assignment.App;
using StarWarsPlanetsStats_Assignment.Model;
using StarWarsPlanetsStats_Assignment.UserInteractions;

public class PlanetsStatisticalAnalyzer : IPlanetsStatisticalAnalyzer
{

    private readonly IPlanetsStatsUserInteractor _planetsStatsUserInteractor;

    public PlanetsStatisticalAnalyzer(IPlanetsStatsUserInteractor planetsStatsUserInteractor)
    {
        _planetsStatsUserInteractor = planetsStatsUserInteractor;
    }

    public void Analyze(IEnumerable<Planet> planets)
    {
        var propertyNamesToSelectorsMapping = new Dictionary<string, Func<Planet, long?>>
        {
            ["Population"] = planet => planet.Population,
            ["Diameter"] = planet => planet.Diameter,
            ["SurfaceWater"] = planet => planet.SurfaceWater,
        };

        var userChoice = _planetsStatsUserInteractor.ChooseStatisticToBeShown(propertyNamesToSelectorsMapping.Keys);

        if (userChoice is null || !propertyNamesToSelectorsMapping.ContainsKey(userChoice))
        {
            _planetsStatsUserInteractor.ShowMessage("Invalid choice.");
        }
        else if (propertyNamesToSelectorsMapping.ContainsKey(userChoice))
        {
            ShowStatistics(planets, userChoice, propertyNamesToSelectorsMapping[userChoice]);
        }
    }

    public void ShowStatistics(
        IEnumerable<Planet> planets,
        string propertyName,
        Func<Planet, long?> propertySelctor
    )
    {
        ShowStatistics(
            "Max",
            planets.MaxBy(propertySelctor),
            propertySelctor,
            propertyName
        );
        ShowStatistics(
            "Min",
            planets.MinBy(propertySelctor),
            propertySelctor,
            propertyName
        );
    }

    private void ShowStatistics(
        string descriptor,
        Planet selectedPlanet,
        Func<Planet, long?> propertySelctor,
        string propertyName)
    {
        _planetsStatsUserInteractor.ShowMessage($"" +
            $"{descriptor} {propertyName} Is: {propertySelctor(selectedPlanet)}  " +
            $"\n planet: {selectedPlanet.Name}");
    }
}


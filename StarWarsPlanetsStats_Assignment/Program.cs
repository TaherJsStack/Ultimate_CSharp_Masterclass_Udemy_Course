using StarWarsPlanetsStats_Assignment.ApiDataAccess;
using StarWarsPlanetsStats_Assignment.UserInteractions;

const string baseAddress = "https://swapi.dev/";
const string requestUri = "api/planets";

try
{
    await new StarWarsPlanetStatsApp(
        new PlanetsFromAPIReader(
            new ApiDataReader(),
            new MockStarWarsApiDataReader()
        ),
        new PlanetsStatisticalAnalyzer(
            new PlanetsStatsUserInteractor(
                new ConsoleUserInteractor()
            )
        ),
        new PlanetsStatsUserInteractor(
                new ConsoleUserInteractor()
            )
    ).Run(baseAddress, requestUri);
}
catch( Exception ex)
{
    Console.WriteLine(ex);
}

Console.ReadKey();


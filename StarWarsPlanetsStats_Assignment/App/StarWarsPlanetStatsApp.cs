using StarWarsPlanetsStats_Assignment.App;
using StarWarsPlanetsStats_Assignment.UserInteractions;

public class StarWarsPlanetStatsApp
{

    private readonly IPlanetsReader _planetsReader;
    private readonly IPlanetsStatisticalAnalyzer _planetsStatisticalAnalyzer;
    private readonly IPlanetsStatsUserInteractor _planetsStatsUserInteractor;

    public StarWarsPlanetStatsApp(IPlanetsReader planetsReader, IPlanetsStatisticalAnalyzer planetsStatisticalAnalyzer, IPlanetsStatsUserInteractor planetsStatsUserInteractor)
    {
        _planetsReader = planetsReader;
        _planetsStatisticalAnalyzer = planetsStatisticalAnalyzer;
        _planetsStatsUserInteractor = planetsStatsUserInteractor;
    }

    public async Task Run(string baseAddress, string requestUri)
    {
        var planets = await _planetsReader.Read(baseAddress, requestUri);
        _planetsStatsUserInteractor.Show(planets);
        _planetsStatisticalAnalyzer.Analyze(planets);
    }
}


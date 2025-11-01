using StarWarsPlanetsStats_Assignment.Model;

namespace StarWarsPlanetsStats_Assignment.App
{
    public interface IPlanetsStatisticalAnalyzer
    {
        void Analyze(IEnumerable<Planet> planets);
    }
}
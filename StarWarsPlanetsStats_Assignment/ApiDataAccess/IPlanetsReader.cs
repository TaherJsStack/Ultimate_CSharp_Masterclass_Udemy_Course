using StarWarsPlanetsStats_Assignment.Model;

public interface IPlanetsReader
{
    Task<IEnumerable<Planet>> Read(string baseAddress, string requestUri);
}


namespace StarWarsPlanetsStats_Assignment.ApiDataAccess;

public interface IApiDataReader
{
    Task<string> Read(string baseAddress, string requestUri);
}

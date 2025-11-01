using StarWarsPlanetsStats_Assignment.ApiDataAccess;
using StarWarsPlanetsStats_Assignment.DTOs;
using StarWarsPlanetsStats_Assignment.Model;
using System.Text.Json;

public class PlanetsFromAPIReader : IPlanetsReader
{
    private readonly IApiDataReader _apiDataReader;
    private readonly IApiDataReader _mockStarWarsApiDataReader;

    public PlanetsFromAPIReader(IApiDataReader apiDataReader, IApiDataReader mockStarWarsApiDataReader)
    {
        _apiDataReader = apiDataReader;
        _mockStarWarsApiDataReader = mockStarWarsApiDataReader;
    }

    public async Task<IEnumerable<Planet>> Read(string baseAddress, string requestUri)
    {
        string? stringDataJson = null;

        try
        {
            stringDataJson = await _apiDataReader.Read(baseAddress, requestUri);
        }
        catch (HttpRequestException ex)
        {
            Console.WriteLine(" API request was unsuccessful. ");
            Console.WriteLine(" Switching to mock data");
            Console.WriteLine(ex.ToString());
        }

        stringDataJson ??= await _mockStarWarsApiDataReader.Read(baseAddress, requestUri);
        var root = JsonSerializer.Deserialize<Root>(stringDataJson);

        return ToPlanets(root);
    }

    private static IEnumerable<Planet> ToPlanets(Root? root)
    {
        return root == null ? throw new ArgumentNullException(nameof(root)) : root.results.Select(planetDto => (Planet)planetDto);
    }
}


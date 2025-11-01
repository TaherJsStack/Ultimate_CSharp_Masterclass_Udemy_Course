using StarWarsPlanetsStats_Assignment.DTOs;
using StarWarsPlanetsStats_Assignment.Utilities;

namespace StarWarsPlanetsStats_Assignment.Model
{
    public readonly record struct Planet
    {
        public string Name { get; }
        public int Diameter { get; }
        public int? SurfaceWater { get; }
        public long? Population { get; }

        public Planet(
            string name,
            int diameter,
            int? surfaceWater,
            long? population
        )
        {
            Name = name;
            Diameter = diameter;
            SurfaceWater = surfaceWater;
            Population = population;

            ArgumentNullException.ThrowIfNull(name);
        }

        public static explicit operator Planet(Result planetDto)
        {
            var name = planetDto.name;
            var diameter = int.Parse(planetDto.diameter);

            long? population = planetDto.population.ToLongOrNull();
            int? surfaceWater = planetDto.surface_water.ToIntOrNull();

            return new Planet(name, diameter, surfaceWater, population);
        }
    };
}
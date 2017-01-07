using CityInfo.API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CityInfo.API
{
    public static class CityInfoContextExtensions
    {
        public static void EnsureSeedDataForContext(this CityInfoContext context)
        {
            if (context.Cities.Any())
            {
                return;
            }

            List<City> cities = new List<City>()
            {
                new City()
                {
                    Name = "New York City",
                    Description = "Something about New York City.",
                    PointsOfInterest = new List<PointOfInterest>()
                    {
                        new PointOfInterest()
                        {
                            Name = "Central Park",
                            Description = "A big park."
                        },
                        new PointOfInterest()
                        {
                            Name = "Empire State Building",
                            Description = "A big building."
                        }
                    }
                },
                new City()
                {
                    Name = "Antwerp",
                    Description = "Something about Antwerp."
                },
                new City()
                {
                    Name = "Paris",
                    Description = "Something about Paris."
                }
            };

            context.Cities.AddRange(cities);

            context.SaveChanges();
        }
    }
}

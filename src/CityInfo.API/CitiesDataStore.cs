using CityInfo.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CityInfo.API
{
  public class CitiesDataStore
  {
    public static CitiesDataStore Current { get; } = new CitiesDataStore();
    public List<CityDto> Cities { get; set; }

    public CitiesDataStore()
    {
      //Cities = new List<CityDto>()
      //{
      //  new CityDto()
      //  {
      //    Id = 1,
      //    Name = "New York City",
      //    Description = "Something about New York City.",
      //    PointsOfInterest = new List<PointsOfInterestDto>()
      //    {
      //      new PointsOfInterestDto()
      //      {
      //        Id = 1,
      //        Name = "Central Park",
      //        Description = "A big park."
      //      },
      //      new PointsOfInterestDto()
      //      {
      //        Id = 2,
      //        Name = "Empire State Building",
      //        Description = "A big building."
      //      }
      //    }
      //  },
      //  new CityDto()
      //  {
      //    Id = 2,
      //    Name = "Antwerp",
      //    Description = "Something about Antwerp."
      //  },
      //  new CityDto()
      //  {
      //    Id = 3,
      //    Name = "Paris",
      //    Description = "Something about Paris."
      //  }
      //};
    }
  }
}

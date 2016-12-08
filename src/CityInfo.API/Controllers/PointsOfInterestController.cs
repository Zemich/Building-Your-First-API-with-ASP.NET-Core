using CityInfo.API.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CityInfo.API.Controllers
{
  [Route("api/cities")]
  public class PointsOfInterestController : Controller
  {
    [HttpGet("{cityId}/pointsofinterest")]
    public IActionResult GetPointsOfInterest(int cityId)
    {
      CityDto city = CitiesDataStore.Current.Cities.FirstOrDefault(c => c.Id == cityId);

      if (city == null)
      {
        return NotFound();
      }

      return Ok(city.PointsOfInterest);
    }

    [HttpGet("{cityId}/pointsofinterest/{id}")]
    public IActionResult GetPointOfInterest(int cityId, int id)
    {
      CityDto city = CitiesDataStore.Current.Cities.FirstOrDefault(c => c.Id == cityId);

      if (city == null)
      {
        return NotFound();
      }

      PointsOfInterestsDto pointOfInterest = city.PointsOfInterest.FirstOrDefault(c => c.Id == id);

      if (pointOfInterest == null)
      {
        return NotFound();
      }

      return Ok(pointOfInterest);
    }
  }
}

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

    [HttpGet("{cityId}/pointsofinterest/{id}", Name = "GetPointOfInterest")]
    public IActionResult GetPointOfInterest(int cityId, int id)
    {
      CityDto city = CitiesDataStore.Current.Cities.FirstOrDefault(c => c.Id == cityId);

      if (city == null)
      {
        return NotFound();
      }

      PointsOfInterestDto pointOfInterest = city.PointsOfInterest.FirstOrDefault(c => c.Id == id);

      if (pointOfInterest == null)
      {
        return NotFound();
      }

      return Ok(pointOfInterest);
    }

    [HttpPost("{cityId}/pointsofinterest")]
    public IActionResult CreatePointOfInterest(int cityId, [FromBody] PointOfInterestForCreationDto pointOfInterest)
    {
      if (pointOfInterest == null)
      {
        return BadRequest();
      }

      CityDto city = CitiesDataStore.Current.Cities.FirstOrDefault(c => c.Id == cityId);

      if (city == null)
      {
        return NotFound();
      }

      int maxPointOfInterestId = CitiesDataStore.Current.Cities.SelectMany(c => c.PointsOfInterest).Max(p => p.Id);

      PointsOfInterestDto finalPointOfInterest = new PointsOfInterestDto()
      {
        Id = ++maxPointOfInterestId,
        Name = pointOfInterest.Name,
        Description = pointOfInterest.Description
      };

      city.PointsOfInterest.Add(finalPointOfInterest);

      return CreatedAtRoute("GetPointOfInterest", new { cityId = cityId, id = finalPointOfInterest.Id }, finalPointOfInterest);
    }
  }
}

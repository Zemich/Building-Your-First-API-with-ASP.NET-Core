using CityInfo.API.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CityInfo.API.Controllers
{
  //[Route("api/[controller]")] can be used if you want the classname to reflect the url
  [Route("api/cities")]
  public class CitiesController : Controller
  {
    [HttpGet()]
    public IActionResult GetCities()
    {
      return Ok(CitiesDataStore.Current.Cities);
    }

    [HttpGet("{id}")]
    public IActionResult GetCity(int id)
    {
      CityDto cityToReturn = CitiesDataStore.Current.Cities.FirstOrDefault(c => c.Id == id);

      if (cityToReturn == null)
      {
        return NotFound();
      }

      return Ok(cityToReturn);
    }
  }
}

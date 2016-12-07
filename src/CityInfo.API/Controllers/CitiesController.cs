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
    public JsonResult GetCities()
    {
      return new JsonResult(CitiesDataStore.Current.Cities);
    }

    [HttpGet("{id}")]
    public JsonResult GetCity(int id)
    {
      return new JsonResult(CitiesDataStore.Current.Cities.FirstOrDefault(c => c.Id == id));
    }
  }
}

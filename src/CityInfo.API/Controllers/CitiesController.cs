﻿using AutoMapper;
using CityInfo.API.Models;
using CityInfo.API.Services;
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
        private ICityInfoRepository _cityInfoRepository;

        public CitiesController(ICityInfoRepository cityInfoRepository)
        {
            _cityInfoRepository = cityInfoRepository;
        }

        [HttpGet()]
        public IActionResult GetCities()
        {
            //return Ok(CitiesDataStore.Current.Cities);
            var cityEntities = _cityInfoRepository.GetCities();

            var results = Mapper.Map<IEnumerable<CityWithoutPointsOfInterestDto>>(cityEntities);
            
            //Example of mapping without automapper
            //var result = new List<CityWithoutPointsOfInterestDto>();
            //foreach (var cityEntity in cityEntities)
            //{
            //    result.Add(new CityWithoutPointsOfInterestDto
            //    {
            //        Id = cityEntity.Id,
            //        Description = cityEntity.Description,
            //        Name = cityEntity.Name
            //    });
            //}

            return Ok(results);
        }

        [HttpGet("{id}")]
        public IActionResult GetCity(int id, bool includePointsOfInterest = false)
        {
            var city = _cityInfoRepository.GetCity(id, includePointsOfInterest);

            if (city == null)
            {
                return NotFound();
            }

            if (includePointsOfInterest)
            {
                //before automapper
                //var cityResult = new CityDto()
                //{
                //    Id = city.Id,
                //    Name = city.Name,
                //    Description = city.Description
                //};

                //foreach (var poi in city.PointsOfInterest)
                //{
                //    cityResult.PointsOfInterest.Add(
                //        new PointsOfInterestDto()
                //        {
                //            Id = poi.Id,
                //            Name = poi.Name,
                //            Description = poi.Description
                //        });
                //}

                var cityResult = Mapper.Map<CityDto>(city);
                return Ok(cityResult);
            }

            //Before automapper
            //var cityWithoutPointsOfInterestResult = new CityWithoutPointsOfInterestDto
            //{
            //    Id = city.Id,
            //    Description = city.Description,
            //    Name = city.Name
            //};

            var cityWithoutPointsOfInterestResult = Mapper.Map<CityWithoutPointsOfInterestDto>(city);

            return Ok(cityWithoutPointsOfInterestResult);

            //CityDto cityToReturn = CitiesDataStore.Current.Cities.FirstOrDefault(c => c.Id == id);

            //if (cityToReturn == null)
            //{
            //    return NotFound();
            //}

            //return Ok(cityToReturn);
        }
    }
}
